// <copyright file="GraduationTrackerTests.cs" company="Xello">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GraduationTracker.Tests.Unit
{
    using System;
    using System.Collections.Generic;
    using Graduation.BAL;
    using Graduation.Models;
    using Graduation.Repository;
    using Graduation.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GraduationTrackerTests
    {
        // AdarshSharma: Global Declarations
        public GraduationTracker Tracker { get; set; } = new GraduationTracker();

        public bool IsGraduated { get; set; } = false;

        private readonly Diploma diploma = Repository.GetDiploma(1);

        private Course[] course = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark = 0 },
                    new Course{Id = 2, Name = "Science", Mark = 0 },
                    new Course{Id = 3, Name = "Literature", Mark = 0 },
                    new Course{Id = 4, Name = "Physichal Education", Mark = 0 }
                };

        /// <summary>
        /// test if the single student is graduated
        /// </summary>
        [TestMethod]
        public void TestStudentHasGraduated()
        {
            var students = Repository.GetStudent(1);

            var graduated = new List<Tuple<bool, STANDING>>();

            // iteam 1 is the boolean value if the student is graduated or not based on the business logic
            Assert.IsTrue(this.Tracker.HasGraduated(students, this.diploma).Item1 == true);
        }

        /// <summary>
        /// test if the any student form the list is graduated
        /// </summary>
        [TestMethod]
        public void TestStudentHasNotGraduated()
        {
            Student student =
               new Student
               {
                   Id = 1,
                   Courses = this.course
               };

            // iteam 1 is the boolean value if the student is graduated or not based on the business logic
            Assert.IsTrue(this.Tracker.HasGraduated(student, this.diploma).Item1 == false);
        }

        /// <summary>
        /// test student is not graduated
        /// </summary>
        [TestMethod]
        public void TestAnyStudentHasGraduated()
        {
            Student[] students = new Student[] { Repository.GetStudent(1), Repository.GetStudent(2), Repository.GetStudent(3), Repository.GetStudent(4) };

            foreach (var student in students)
            {
                // iteam 1 is the boolean value if the student is graduated or not based on the business logic
                if (this.Tracker.HasGraduated(student, this.diploma).Item1 == true)
                {
                    this.IsGraduated = true;
                }

                Assert.IsTrue(this.IsGraduated);
            }
        }

        /// <summary>
        /// test no one from the list is graduated
        /// </summary>
        [TestMethod]
        public void TestNoneStudentHasGraduated()
        {
            var students = new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = this.course
               },
               new Student
               {
                   Id = 2,
                   Courses = this.course
               },
            new Student
            {
                Id = 3,
                Courses = this.course
            },
            new Student
            {
                Id = 4,
                Courses = this.course
            }
        };

            foreach (var student in students)
            {
                // iteam 1 is the boolean value if the student is graduated or not based on the business logic
                if (this.Tracker.HasGraduated(student, this.diploma).Item1 == false)
                {
                    this.IsGraduated = false;
                }

                Assert.IsFalse(this.IsGraduated);
            }
        }
    }
}
