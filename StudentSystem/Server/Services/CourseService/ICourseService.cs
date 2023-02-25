namespace StudentSystem.Server.Services.CourseService
{
    public interface ICourseService
    {
        Task<ServiceResponse<List<Course>>> GetCoursesAysnc();
        Task<ServiceResponse<Course>> GetCourseAsync(int courseId);
        Task<ServiceResponse<CourseSearchResultDTO>> SearchCourses(string searchText, int Page);
        Task<ServiceResponse<List<string>>> getCourseSuggestions(string searchText);
    }
}
