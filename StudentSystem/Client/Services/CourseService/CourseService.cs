using System.Net.Http.Json;
namespace StudentSystem.Client.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient _http;
        public event Action CoursesChanged;

        public CourseService(HttpClient http)
        {
            _http = http;
        }

        public List<Course> Courses { get; set; } = new List<Course>();
        public string Message { get; set; } = "Loading Products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;
        public async Task<ServiceResponse<Course>> GetCourse(int courseId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Course>>($"api/Course/{courseId}");
            return result;
        }



        public async Task GetCourses()
        {
            //asynchronous operation that returns a task object -> Sends a get request and deserialize the response body as json 
            var result =
            await _http.GetFromJsonAsync<ServiceResponse<List<Course>>>("api/Course");
            if (result != null && result.Data != null)
                //getting resulted data and assign its values to list of courses to utilize it in HTML body of the course list component 
                Courses = result.Data;
                CurrentPage = 1;
                PageCount = 0;
            if(Courses.Count == 0)
            {
                Message = "No Course Found";
            }

            CoursesChanged?.Invoke();

        }

        public async Task<List<string>> GetCourseSearchSuggestions(string searchText)
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<string>>>($"api/course/searchsuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchCourses(string searchText,int page)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<CourseSearchResultDTO>>($"api/course/search/{searchText}/{page}");
            if (result != null && result.Data != null)
            {
                Courses = result.Data.Courses;
                CurrentPage = result.Data.CurrentPage;
                PageCount = result.Data.Pages;
            }
            if (Courses.Count == 0) Message = "No Products found";
            CoursesChanged?.Invoke();
        }
    }
}
