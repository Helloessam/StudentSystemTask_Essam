using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using StudentSystem.Server.Services.CourseService;
using StudentSystem.Shared;

namespace StudentSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Course>>>> GetCourses()
        {
            var result = await _courseService.GetCoursesAysnc();
            
            return Ok(result);
        }

        [HttpGet("{courseId}")]
       
        public async Task<ActionResult<ServiceResponse<Course>>> GetCourse(int courseId)
        {
            var result = await _courseService.GetCourseAsync(courseId);

            return Ok(result);
        }


        [HttpGet("search/{searchText}/{page}")]
        public async Task<ActionResult<ServiceResponse<CourseSearchResultDTO>>> SearchCourses(string searchText,int page)
        {
            var result = await _courseService.SearchCourses(searchText,page);

            return Ok(result);
        }



        [HttpGet("searchsuggestions/{searchText}")]
        public async Task<ActionResult<ServiceResponse<List<Course>>>> GetCourseSearchSuggestions(string searchText)
        {
            var result = await _courseService.getCourseSuggestions(searchText);

            return Ok(result);
        }

    }
}

