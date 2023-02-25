﻿// <auto-generated />
using System;
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
    [Migration("20221210005520_ScheduleItems")]
    partial class ScheduleItems
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
                    b.Property<int>("courseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("courseId"));

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

                    b.HasKey("courseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            courseId = 155,
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
                            courseId = 145,
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
                            courseId = 135,
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
                            courseId = 295,
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
                            courseId = 104,
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
                            courseId = 284,
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
                            courseId = 109,
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

                    b.Property<int?>("courseId")
                        .HasColumnType("int");

                    b.Property<string>("lecturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("lecturerId");

                    b.HasIndex("courseId");

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
                    b.Property<int>("courseId")
                        .HasColumnType("int");

                    b.Property<int>("CourseLecturerId")
                        .HasColumnType("int");

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("courseId", "CourseLecturerId");

                    b.HasIndex("CourseLecturerId");

                    b.ToTable("CourseVariants");

                    b.HasData(
                        new
                        {
                            courseId = 155,
                            CourseLecturerId = 1331,
                            ClassId = "341A"
                        },
                        new
                        {
                            courseId = 155,
                            CourseLecturerId = 1344,
                            ClassId = "201C"
                        },
                        new
                        {
                            courseId = 135,
                            CourseLecturerId = 3928,
                            ClassId = "414B"
                        },
                        new
                        {
                            courseId = 135,
                            CourseLecturerId = 3121,
                            ClassId = "341A"
                        },
                        new
                        {
                            courseId = 284,
                            CourseLecturerId = 9028,
                            ClassId = "201G"
                        },
                        new
                        {
                            courseId = 284,
                            CourseLecturerId = 5005,
                            ClassId = "201G"
                        },
                        new
                        {
                            courseId = 145,
                            CourseLecturerId = 1344,
                            ClassId = "545A"
                        },
                        new
                        {
                            courseId = 295,
                            CourseLecturerId = 3121,
                            ClassId = "101G"
                        },
                        new
                        {
                            courseId = 104,
                            CourseLecturerId = 4356,
                            ClassId = "405A"
                        },
                        new
                        {
                            courseId = 109,
                            CourseLecturerId = 5005,
                            ClassId = "100G"
                        });
                });

            modelBuilder.Entity("StudentSystem.Shared.ScheduleItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CourseId", "LecturerId");

                    b.ToTable("ScheduleItem");
                });

            modelBuilder.Entity("StudentSystem.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Regnum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentSystem.Shared.CourseLecturer", b =>
                {
                    b.HasOne("StudentSystem.Shared.Course", null)
                        .WithMany("CourseLecturer")
                        .HasForeignKey("courseId");
                });

            modelBuilder.Entity("StudentSystem.Shared.CourseVariant", b =>
                {
                    b.HasOne("StudentSystem.Shared.CourseLecturer", "CourseLecturer")
                        .WithMany()
                        .HasForeignKey("CourseLecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentSystem.Shared.Course", "Course")
                        .WithMany("Variants")
                        .HasForeignKey("courseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("CourseLecturer");
                });

            modelBuilder.Entity("StudentSystem.Shared.Course", b =>
                {
                    b.Navigation("CourseLecturer");

                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
