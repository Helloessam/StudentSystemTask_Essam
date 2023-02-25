namespace StudentSystem.Client.Services.ScheduleService
{
    public interface IScheduleService
    {
        event Action OnChange;
        Task <string> AddToSchedule(ScheduleItem scheduleItem);
       // Task<List<ScheduleItem>> GetScheduleItems(List<ScheduleItem> scheduleItems);

        Task<List<ScheduleCourseResponse>> GetScheduleCourses();
        Task RemoveCourseFromSchedule(int courseId,int courseLecturerId);

        Task StoreScheduleItems(bool emptyLocalSchedule);

        Task GetScheduleItemsCount();
        
    }
}
