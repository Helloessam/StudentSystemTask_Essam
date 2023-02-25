namespace StudentSystem.Client.Services.CourseService
{
    public interface ICourseService
    {
        event Action CoursesChanged;
        List<Course> Courses { get; set; }
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        string LastSearchText { get; set; }
        Task GetCourses();
        Task<ServiceResponse<Course>> GetCourse(int courseId);

        Task SearchCourses(string searchText,int page);
        Task<List<string>> GetCourseSearchSuggestions(string searchText);

    }
}
