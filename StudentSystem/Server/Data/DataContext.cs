using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading.Channels;

namespace StudentSystem.Server.Data
{
    //DbContext and DbSet provided as part of the EF Code-First library.
    //represents a Session between your program & a Database.
    //allows your program to send & retrieve data to/from a Database.
    /**********************************************************************/
    //DbContext is used for EF (EntityFramework) and DataContext is used for L2S (LINQ To SQL).
    // DbContext is a class you create in your program that inherits from DbContext.
    //DbContext use DataContext to retrieve or update data locally in your program.
    //then push changes (using methods from the inherited DbContext) to the actual Database to update it.

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduleItem>()
               .HasKey(si => new { si.UserId, si.CourseId, si.LecturerId });

            modelBuilder.Entity<CourseVariant>()
                .HasKey(p => new { p.courseId, p.CourseLecturerId });
            // builder that's used construct model for Context.database 
            //.HasData Add seed data to this entity type for Seeding Data Migration 
            modelBuilder.Entity<Course>().HasData(
            new Course { courseId = 155, CourseName = "Python Programming", CreditHours = 3, Day = 1, Depratment = "Computer Engineering", DepratmentId = 1, LecturerName = "Dr.Mohammed", Timeslot = 1 },
            new Course { courseId = 145, CourseName = "Java Programming", CreditHours = 3, Day = 1, Depratment = "Computer Engineering", DepratmentId = 1, LecturerName = "Dr.Mostafa", Timeslot = 2 },
            new Course { courseId = 135, CourseName = "C++ Programming", CreditHours = 3, Day = 1, Depratment = "Computer Engineering", DepratmentId = 1, LecturerName = "Dr.Aly", Timeslot = 3 },
            new Course { courseId = 295, CourseName = "Maths", CreditHours = 3, Day = 2, Depratment = "Mechanical Engineering", DepratmentId = 2, LecturerName = "Dr.Ola", Timeslot = 1 },
            new Course { courseId = 104, CourseName = "Economy", CreditHours = 3, Day = 2, Depratment = "Computer Engineering", DepratmentId = 1, LecturerName = "Dr.Saad", Timeslot = 2 },
            new Course { courseId = 284, CourseName = "Dynamics", CreditHours = 3, Day = 2, Depratment = "Mechanical Engineering", DepratmentId = 2, LecturerName = "Dr.Abdullah", Timeslot = 3 },
            new Course { courseId = 109, CourseName = "Statistics", CreditHours = 3, Day = 3, Depratment = "Mechanical Engineering", DepratmentId = 2, LecturerName = "Dr.Omar", Timeslot = 4 }
                );

            modelBuilder.Entity<CourseLecturer>().HasData(
                    new CourseLecturer { lecturerId = 1331, lecturerName = "Dr.Mohamed" },
                    new CourseLecturer { lecturerId = 1344, lecturerName = "Dr.Mostafa" },
                    new CourseLecturer { lecturerId = 3928, lecturerName = "Dr.Aly" },
                    new CourseLecturer{lecturerId = 3121, lecturerName = "Dr.Ola"},
                    new CourseLecturer{lecturerId = 4356, lecturerName = "Dr.Saad"},
                    new CourseLecturer{lecturerId = 9028, lecturerName = "Dr.Abdullah"},
                    new CourseLecturer { lecturerId = 5005, lecturerName = "Dr.Omar" }
                );

            modelBuilder.Entity<CourseVariant>().HasData(
                   new CourseVariant { courseId = 155, CourseLecturerId = 1331, ClassId ="341A"},
                   new CourseVariant { courseId = 155, CourseLecturerId = 1344, ClassId = "201C" },
                   new CourseVariant { courseId = 135, CourseLecturerId = 3928, ClassId = "414B" },
                   new CourseVariant { courseId = 135, CourseLecturerId = 3121, ClassId = "341A" },
                   new CourseVariant { courseId = 284, CourseLecturerId = 9028, ClassId = "201G" },
                   new CourseVariant { courseId = 284, CourseLecturerId = 5005, ClassId = "201G" },
                    // the rest 
                   new CourseVariant { courseId = 145, CourseLecturerId = 1344, ClassId = "545A" },
                   new CourseVariant { courseId = 295, CourseLecturerId = 3121, ClassId = "101G" },
                   new CourseVariant { courseId = 104, CourseLecturerId = 4356, ClassId = "405A" },
                   new CourseVariant { courseId = 109, CourseLecturerId = 5005, ClassId = "100G" }

               );
        }





        //Dbset can be used to query and save instances of course. LINQ queries against dbset Translated into quieries against the DB
        //DbContext corresponds to  database (or a collection of tables and views in your database)
        // whereas a DbSet corresponds to a table or view in your database.
        //A DbSet represents an entity set. An entity set is defined as a set of entities of the same entity type.
        // From the perspective of  the database, it usually represents the table
        //Courses is refernced in Course Controller in get courses method which perform HTTP Get Method
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLecturer> CourseLecturers { get; set; }
        public DbSet<CourseVariant> CourseVariants { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ScheduleItem> ScheduleItems { get; set; }
    }
}
