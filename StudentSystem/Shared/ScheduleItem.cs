using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Shared
{
    public class ScheduleItem
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public int LecturerId { get; set; }
        public int Capacity { get; set; } = 25;
       
    }
}
