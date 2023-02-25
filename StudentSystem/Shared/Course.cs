namespace StudentSystem.Shared
{   //* Course model with course class attributes 
    public class Course
    {
        public int courseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int DepratmentId { get; set; }
        public string Depratment { get; set; } = string.Empty;
        public string LecturerName { get; set; } = string.Empty;
        public int Day { get; set; }
        public int Timeslot { get; set; }
        public int CreditHours { get; set; }
        public List<CourseVariant> Variants { get; set; } = new List<CourseVariant>();
        public List<CourseLecturer> CourseLecturer { get; set; } = new List<CourseLecturer>();
    }
}
