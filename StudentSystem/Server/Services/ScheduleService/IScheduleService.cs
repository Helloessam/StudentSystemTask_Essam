using StudentSystem.Shared;

namespace StudentSystem.Server.Services.ScheduleService
{
    public interface IScheduleService
    {
       Task<ServiceResponse<List<ScheduleCourseResponse>>> GetScheduledCourses(List<ScheduleItem> scheduleItems);
        Task<ServiceResponse<List<ScheduleCourseResponse>>> StoreScheduleItems(List<ScheduleItem> scheduleItems);
        Task<ServiceResponse<List<ScheduleCourseResponse>>> GetDbScheduleCourses();
        Task<ServiceResponse<bool>> AddToSchedule(ScheduleItem scheduleItem);
        Task<ServiceResponse<int>> GetScheduleItemsCount();
        Task<ServiceResponse<bool>> RemoveItemfromschedule (int courseId , int lecturerId);
    }
}
