using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Shared
{
    public class CourseLecturer
    {
        [Key]
        public int lecturerId { get; set; }
        public string lecturerName { get; set; } = string.Empty;

    }
}
