using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Shared
{
    public class ScheduleCourseResponse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int LecturerID { get; set; }
        public string LecturerName { get; set; } = string.Empty;
        public int DepratmentId { get; set; }
        public string DepratmentName { get; set; } = string.Empty;
        public int Day { get; set; }
        public int Timeslot { get; set; }
        public int CreditHours { get; set; }
        public string ClassId { get; set; } = string.Empty;
        public int capacity { get; set; } 

    }
}
