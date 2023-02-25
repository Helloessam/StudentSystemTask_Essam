using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentSystem.Shared
{
    public class CourseVariant
    {
        [JsonIgnore]
        public Course Course { get; set; }
        public int courseId { get; set; }
        public CourseLecturer CourseLecturer { get; set; }
        public int CourseLecturerId { get; set; }
        public string ClassId { get; set; }
       
    }
}
