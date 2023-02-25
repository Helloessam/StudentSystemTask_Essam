using Blazored.LocalStorage;
using StudentSystem.Client.Pages;
using StudentSystem.Shared;
using System.Reflection.Metadata.Ecma335;

namespace StudentSystem.Client.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public ScheduleService(ILocalStorageService localStorage , HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _localStorage = localStorage;
            _http = http;
            _authStateProvider = authStateProvider;
        }

       

        public event Action OnChange;

        public async Task<string> AddToSchedule(ScheduleItem scheduleItem)
        {
            
            if(await IsUserAuthenticated())
            {
                await _http.PostAsJsonAsync("api/schedule/add", scheduleItem);
            }
            else { }
            
            string Message = string.Empty;
            bool isDuplicate = false;

            bool overLoaded = false;
            List<ScheduleCourseResponse> scheduleCourses = null;
            scheduleCourses = await GetScheduleCourses();
            var schedule = await _localStorage.GetItemAsync<List<ScheduleItem>>("Schedule");
            if (await IsUserAuthenticated())
            {

                if (schedule == null)
                {
                    schedule = new List<ScheduleItem>();
                }
                foreach (var course in schedule)
                {
                    if (course.CourseId == scheduleItem.CourseId)
                    {
                        isDuplicate = true;
                        return Message = "Course Already Selected";
                    }
                    if (course.Capacity < 0)
                    {
                        return Message = "Failed , Class is fully Registered ";
                    }
                    if (scheduleCourses.Sum(course => course.CreditHours) >= 18)
                    {
                        return Message = "Failed, you can Register up to 18 credits hours only ";
                    }
                }


                if (isDuplicate != true)
                {

                    schedule.Add(scheduleItem);
                    await _localStorage.SetItemAsync("Schedule", schedule);
                    scheduleItem.Capacity -= 1;
                    OnChange.Invoke();
                    await _http.PostAsJsonAsync("api/schedule/add", scheduleItem);
                    await GetScheduleItemsCount();
                    return Message = "Successfully added the Course ";
                }
            }
          
            return Message;


        }

        public async Task GetScheduleItemsCount()
        {
            if(await IsUserAuthenticated())
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/schedule/count");
                var count = result.Data;
                
            }else
            {
                var schedule = await _localStorage.GetItemAsync<List<ScheduleItem>>("schedule");
                await _localStorage.SetItemAsync<int>("scheduleItemsCount", schedule != null ? schedule.Count : 0 );
            }
            OnChange.Invoke();
           
        }

        public async Task<List<ScheduleCourseResponse>> GetScheduleCourses()
        {
            if (await IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<ServiceResponse<List<ScheduleCourseResponse>>>("api/schedule");
                return response.Data;
            }
            else { 
                var ScheduleItems = await _localStorage.GetItemAsync<List<ScheduleItem>>("Schedule");
                if (ScheduleItems == null)
                    return new List<ScheduleCourseResponse>();
                var response = await _http.PostAsJsonAsync("api/schedule/courses", ScheduleItems);
                var ScheduleCourses =
                    await response.Content.ReadFromJsonAsync<ServiceResponse<List<ScheduleCourseResponse>>>();
                return ScheduleCourses.Data;
            }
            
        }

      /*  public async Task<List<ScheduleItem>> GetScheduleItems(List<ScheduleItem> scheduleItems)
        {
            var schedule = await _localStorage.GetItemAsync<List<ScheduleItem>>("Schedule");
            if (schedule == null)
            {
                schedule = new List<ScheduleItem>();
            }
            return schedule;
        } */

        public async Task RemoveCourseFromSchedule(int courseId, int courseLecturerId)
        {
            if(await IsUserAuthenticated())
            {
                await _http.DeleteAsync($"api/schedule/{courseId}/{courseLecturerId}");
            }
            else
            {
                var schedule = await _localStorage.GetItemAsync<List<ScheduleItem>>("Schedule");
                if (schedule == null)
                {
                    return;
                }
                var scheduleItem = schedule.Find(x => x.CourseId == courseId && x.LecturerId == courseLecturerId);
                if (scheduleItem != null)
                {
                    schedule.Remove(scheduleItem);
                    await _localStorage.SetItemAsync("Schedule", schedule);
                    
                    OnChange.Invoke();
                }
            }
            //await GetScheduleItemsCount();
        }

        public async Task StoreScheduleItems(bool emptyLocalSchedule = false)
        {
            var localSchedule = await _localStorage.GetItemAsync<List<ScheduleItem>>("Schedule");
            if(localSchedule== null)
            {
                return;
            }
            await _http.PostAsJsonAsync("api/schedule", localSchedule);

            if (emptyLocalSchedule)
            {
                await _localStorage.RemoveItemAsync("Schedule");
            }
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

       
    }
}
