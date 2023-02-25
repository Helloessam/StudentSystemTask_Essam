using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Shared
{
    public class CourseSearchResultDTO
    {
        public List<Course> Courses { get; set; } = new List<Course>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
            

    }
}
