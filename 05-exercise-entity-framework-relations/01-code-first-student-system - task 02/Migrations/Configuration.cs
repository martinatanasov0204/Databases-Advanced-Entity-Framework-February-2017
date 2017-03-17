using System.Collections.Generic;
using _01_code_first_student_system.Models;

namespace _01_code_first_student_system.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<_01_code_first_student_system.SchoolSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "_01_code_first_student_system.SchoolSystemContext";
        }

        protected override void Seed(_01_code_first_student_system.SchoolSystemContext context)
        {

            var student = new Student()
            {
                Name = "Pesho",
                PhoneNumber = "2323432421",
                RegistrationDate = new DateTime(2016, 12, 12),
                Birthdate = new DateTime(1999, 5, 2)
            };

            var student2 = new Student()
            {
                Name = "Gosho",
                PhoneNumber = "76553234325",
                RegistrationDate = new DateTime(2016, 2, 15),
                Birthdate = new DateTime(1995, 8, 19)
            };

            var student3 = new Student()
            {
                Name = "Lesho",
                PhoneNumber = "77652342231",
                RegistrationDate = new DateTime(2015, 3, 23),
                Birthdate = new DateTime(2002, 6, 28)
            };

            var course = new Course()
            {
                Name = "CSharp Database",
                StartDate = new DateTime(2016, 11, 11),
                EndDate = new DateTime(2017, 3, 11),
                Price = 200,
                Students = new List<Student>()
                {
                    student3,
                    student
                }
            };

            var course2 = new Course()
            {
                Name = "CSharp",
                StartDate = new DateTime(2016, 12, 10),
                EndDate = new DateTime(2017, 3, 2),
                Price = 190,
                Students = new List<Student>()
                {
                    student3,
                    student2
                }
            };

            var course3 = new Course()
            {
                Name = "JavaScript",
                StartDate = new DateTime(2017, 1, 5),
                EndDate = new DateTime(2017, 2, 5),
                Price = 100,
                Students = new List<Student>()
                {
                    student2,
                    student,
                    student3
                }
            };

            var resource = new Resources()
            {
                Name = "Videos",
                TypeOfResource = "video",
                URL = "www.someUrl.com",
                Cources = new HashSet<Course>()
                {
                    course,
                    course2
                }
            };
            var resource2 = new Resources()
            {
                Name = "Presentations",
                TypeOfResource = "presentation",
                URL = "www.someUrl2.com",
                Cources = new HashSet<Course>()
                {
                    course,
                    course3
                }
            };
            var resource3 = new Resources()
            {
                Name = "Books",
                TypeOfResource = "document",
                URL = "www.someUrl3.com",
                Cources = new HashSet<Course>()
                {
                    course3,
                    course2,
                    course
                }
            };

            var homework = new Homework()
            {
                Content = "5 tasks",
                ContentType = "application",
                SubmissionDate = new DateTime(2017, 3, 8),
                Student = student
            };

            var homework2 = new Homework()
            {
                Content = "4 tasks",
                ContentType = "pdf",
                SubmissionDate = new DateTime(2017, 3, 11),
                Student = student2,
            };

            var homework3 = new Homework()
            {
                Content = "2 tasks",
                ContentType = "zip",
                SubmissionDate = new DateTime(2017, 3, 10),
                Student = student3
            };

            context.Courses.AddOrUpdate(course);
            context.Courses.AddOrUpdate(course2);
            context.Courses.AddOrUpdate(course3);

            context.Students.AddOrUpdate(student);
            context.Students.AddOrUpdate(student2);
            context.Students.AddOrUpdate(student3);

            context.Resources.AddOrUpdate(resource);
            context.Resources.AddOrUpdate(resource2);
            context.Resources.AddOrUpdate(resource3);

            context.Homeworks.AddOrUpdate(homework);
            context.Homeworks.AddOrUpdate(homework2);
            context.Homeworks.AddOrUpdate(homework3);
        }
    }
}
