using Blazorise;
using Microsoft.Exchange.WebServices.Data;
using StudentSystem.Server.Migrations;
using StudentSystem.Shared;
using System.Security.Claims;

namespace StudentSystem.Server.Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ScheduleService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<ScheduleCourseResponse>>> GetScheduledCourses(List<ScheduleItem> scheduleItems)
        {
            var result = new ServiceResponse<List<ScheduleCourseResponse>>
            {
                Data = new List<ScheduleCourseResponse>()
            };

            foreach (var item in scheduleItems)
            {
                var course = await _context.Courses
                    .Where(p => p.courseId == item.CourseId)
                    .FirstOrDefaultAsync();
                if (course == null)
                {
                    continue;
                }

                var courseVariant = await _context.CourseVariants
                    .Where(v => v.courseId == item.CourseId
                    && v.CourseLecturerId == item.LecturerId)
                    .Include(p => p.CourseLecturer)
                    .FirstOrDefaultAsync();

                if (courseVariant == null)
                {
                    continue;
                }

                var scheduleCourse = new ScheduleCourseResponse
                {
                    CourseId = course.courseId,
                    CourseName = course.CourseName,
                    DepratmentId = course.DepratmentId,
                    DepratmentName = course.Depratment,
                    LecturerID = courseVariant.CourseLecturerId,
                    LecturerName = courseVariant.CourseLecturer.lecturerName,
                    CreditHours = course.CreditHours,
                    Day = course.Day,
                    Timeslot = course.Timeslot,
                    ClassId = courseVariant.ClassId,
                    capacity = item.Capacity

                };
                result.Data.Add(scheduleCourse);
            }
            return result;
        }

        public async Task<ServiceResponse<List<ScheduleCourseResponse>>> StoreScheduleItems(List<ScheduleItem> scheduleItems)
        {
            scheduleItems.ForEach(scheduleItem => scheduleItem.UserId = GetUserId());
            _context.ScheduleItems.AddRange(scheduleItems);
            await _context.SaveChangesAsync();
            return await GetScheduledCourses(
                await _context.ScheduleItems
                .Where(ci => ci.UserId == GetUserId()).ToListAsync());
        }

        public async Task<ServiceResponse<List<ScheduleCourseResponse>>> GetDbScheduleCourses()
        {
            return await GetScheduledCourses(await _context.ScheduleItems
                .Where(si => si.UserId == GetUserId()).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> AddToSchedule(ScheduleItem scheduleItem)
        {
            scheduleItem.UserId = GetUserId();
            var sameItem = await _context.ScheduleItems.FirstOrDefaultAsync(si => si.CourseId == scheduleItem.CourseId && si.LecturerId == si.LecturerId && si.UserId == scheduleItem.UserId);
            if (sameItem == null)
            {
                _context.ScheduleItems.Add(scheduleItem);
                //scheduleItem.Capacity -= 1;
            }
            else
            {
                //sameItem.Capacity += scheduleItem.Capacity;

            }

            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<int>> GetScheduleItemsCount()
        {
            var count = (await _context.ScheduleItems.Where(si => si.UserId == GetUserId()).ToListAsync()).Count();
            return new ServiceResponse<int> { Data = count };
        }

        public async Task<ServiceResponse<bool>> RemoveItemfromschedule(int courseId, int lecturerId)
        {
            var dbScheduleItem = await _context.ScheduleItems.FirstOrDefaultAsync(si => si.CourseId == courseId && si.LecturerId == lecturerId && si.UserId == GetUserId());
            if (dbScheduleItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist"
                };
            }
            _context.ScheduleItems.Remove(dbScheduleItem);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }
    }
}
