﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentSystem.Server.Data;

#nullable disable

namespace StudentSystem.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221202162634_CourseVariants")]
    partial class CourseVariants
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentSystem.Shared.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreditHours")
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("Depratment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepratmentId")
                        .HasColumnType("int");

                    b.Property<string>("LecturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Timeslot")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 155,
                            CourseName = "Python Programming",
                            CreditHours = 3,
                            Day = 1,
                            Depratment = "Computer Engineering",
                            DepratmentId = 1,
                            LecturerName = "Dr.Mohammed",
                            Timeslot = 1
                        },
                        new
                        {
                            CourseId = 145,
                            CourseName = "Java Programming",
                            CreditHours = 3,
                            Day = 1,
                            Depratment = "Computer Engineering",
                            DepratmentId = 1,
                            LecturerName = "Dr.Mostafa",
                            Timeslot = 2
                        },
                        new
                        {
                            CourseId = 135,
                            CourseName = "C++ Programming",
                            CreditHours = 3,
                            Day = 1,
                            Depratment = "Computer Engineering",
                            DepratmentId = 1,
                            LecturerName = "Dr.Aly",
                            Timeslot = 3
                        },
                        new
                        {
                            CourseId = 295,
                            CourseName = "Maths",
                            CreditHours = 3,
                            Day = 2,
                            Depratment = "Mechanical Engineering",
                            DepratmentId = 2,
                            LecturerName = "Dr.Ola",
                            Timeslot = 1
                        },
                        new
                        {
                            CourseId = 104,
                            CourseName = "Economy",
                            CreditHours = 3,
                            Day = 2,
                            Depratment = "Computer Engineering",
                            DepratmentId = 1,
                            LecturerName = "Dr.Saad",
                            Timeslot = 2
                        },
                        new
                        {
                            CourseId = 284,
                            CourseName = "Dynamics",
                            CreditHours = 3,
                            Day = 2,
                            Depratment = "Mechanical Engineering",
                            DepratmentId = 2,
                            LecturerName = "Dr.Abdullah",
                            Timeslot = 3
                        },
                        new
                        {
                            CourseId = 109,
                            CourseName = "Statistics",
                            CreditHours = 3,
                            Day = 3,
                            Depratment = "Mechanical Engineering",
                            DepratmentId = 2,
                            LecturerName = "Dr.Omar",
                            Timeslot = 4
                        });
                });

            modelBuilder.Entity("StudentSystem.Shared.CourseLecturer", b =>
                {
                    b.Property<int>("lecturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("lecturerId"));

                    b.Property<string>("lecturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("lecturerId");

                    b.ToTable("CourseLecturers");

                    b.HasData(
                        new
                        {
                            lecturerId = 1331,
                            lecturerName = "Dr.Mohamed"
                        },
                        new
                        {
                            lecturerId = 1344,
                            lecturerName = "Dr.Mostafa"
                        },
                        new
                        {
                            lecturerId = 3928,
                            lecturerName = "Dr.Aly"
                        },
                        new
                        {
                            lecturerId = 3121,
                            lecturerName = "Dr.Ola"
                        },
                        new
                        {
                            lecturerId = 4356,
                            lecturerName = "Dr.Saad"
                        },
                        new
                        {
                            lecturerId = 9028,
                            lecturerName = "Dr.Abdullah"
                        },
                        new
                        {
                            lecturerId = 5005,
                            lecturerName = "Dr.Omar"
                        });
                });

            modelBuilder.Entity("StudentSystem.Shared.CourseVariant", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("CourseLecturerId")
                        .HasColumnType("int");

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId", "CourseLecturerId");

                    b.HasIndex("CourseLecturerId");

                    b.ToTable("CourseVariants");

                    b.HasData(
                        new
                        {
                            CourseId = 155,
                            CourseLecturerId = 1331,
                            ClassId = "341A"
                        },
                        new
                        {
                            CourseId = 155,
                            CourseLecturerId = 1344,
                            ClassId = "201C"
                        },
                        new
                        {
                            CourseId = 135,
                            CourseLecturerId = 3928,
                            ClassId = "414B"
                        },
                        new
                        {
                            CourseId = 135,
                            CourseLecturerId = 3121,
                            ClassId = "341A"
                        },
                        new
                        {
                            CourseId = 284,
                            CourseLecturerId = 9028,
                            ClassId = "201G"
                        },
                        new
                        {
                            CourseId = 284,
                            CourseLecturerId = 5005,
                            ClassId = "201G"
                        });
                });

            modelBuilder.Entity("StudentSystem.Shared.CourseVariant", b =>
                {
                    b.HasOne("StudentSystem.Shared.Course", "Course")
                        .WithMany("Variants")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentSystem.Shared.CourseLecturer", "CourseLecturer")
                        .WithMany()
                        .HasForeignKey("CourseLecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("CourseLecturer");
                });

            modelBuilder.Entity("StudentSystem.Shared.Course", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}