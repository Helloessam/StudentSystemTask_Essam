using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentSystem.Server.Services.ScheduleService;
using System.Security.Claims;

namespace StudentSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService  scheduleService)
        {
            _scheduleService = scheduleService;
        }


        [HttpPost("courses")]
        public async Task<ActionResult<ServiceResponse<List<ScheduleCourseResponse>>>> GetScheduleCourses(List<ScheduleItem> scheduleItems)
        {
            var result = await _scheduleService.GetScheduledCourses(scheduleItems);
            return Ok(result);
        }



        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ScheduleCourseResponse>>>> StoreScheduleItems(List<ScheduleItem> ScheduleItem)
        {
            var result = await _scheduleService.StoreScheduleItems(ScheduleItem);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ScheduleCourseResponse>>>> GetDbScheduleCourses()
        {
            var result = await _scheduleService.GetDbScheduleCourses();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddToSchedule(ScheduleItem ScheduleItem)
        {
            var result = await _scheduleService.AddToSchedule(ScheduleItem);
            return Ok(result);
        }

        [HttpDelete("{courseId}/{lecturerId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> RemoveItemfromSchedule(int courseId, int lecturerId)
        {
            var result = await _scheduleService.RemoveItemfromschedule(courseId,lecturerId);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetScheduleItemsCount()
        {
            return await _scheduleService.GetScheduleItemsCount();
        }
    }
}
