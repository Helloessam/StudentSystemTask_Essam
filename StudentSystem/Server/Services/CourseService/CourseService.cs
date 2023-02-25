using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace StudentSystem.Server.Services.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _context;

        public CourseService(DataContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<List<Course>>> GetCoursesAysnc()
        {
            var response = new ServiceResponse<List<Course>>
            {
                Data = await _context.Courses.Include(p => p.Variants).ToListAsync()
            };
            return response;
        }


        public async Task<ServiceResponse<Course>> GetCourseAsync(int courseId)
        {
            var response = new ServiceResponse<Course>();
            var course = await _context.Courses
            .Include(p => p.Variants)
            .ThenInclude(v => v.CourseLecturer)
            .FirstOrDefaultAsync(P => P.courseId == courseId);

            if (course == null)
            {
                response.Success = false;
                response.Message = "Sorry But the course Doesn't exist ";
            }
            else
            {
                response.Data = course;
            }
            return response;
        }

        public async Task<ServiceResponse<CourseSearchResultDTO>> SearchCourses(string searchText,int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindCourseBySearchText(searchText)).Count/pageResults);
            var courses = await _context.Courses
                            .Where(p => p.CourseName.ToLower().Contains(searchText.ToLower())
                            ||
                             p.courseId.ToString().Contains(searchText.ToLower()))
                            .Include(p => p.Variants)
                            .Skip((page - 1) * (int)pageResults)
                            .Take((int)pageResults)
                            .ToListAsync();
            var response = new ServiceResponse<CourseSearchResultDTO>
            {
                Data = new CourseSearchResultDTO
                {
                    Courses = courses,
                    CurrentPage = page,
                    Pages = (int)pageCount
                 }
        };
            return response;
        }

        private async Task<List<Course>> FindCourseBySearchText(string searchText)
        {
            return await _context.Courses
                            .Where(p => p.CourseName.ToLower().Contains(searchText.ToLower())
                            ||
                            p.courseId.ToString().Contains(searchText.ToLower()))
                            .Include(p => p.Variants)
                            .ToListAsync();
        }

        public async Task<ServiceResponse<List<string>>> getCourseSuggestions(string searchText)
        {
            var courses = await FindCourseBySearchText(searchText);
            List<string> result = new List<string>();
            foreach (var course in courses) {
                if (course.CourseName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(course.CourseName);
                }
            }
            return new ServiceResponse<List<string>> { Data = result };
        }
    }

    
}
