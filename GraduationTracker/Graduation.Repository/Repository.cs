// <copyright file="Repository.cs" company="Xello">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Graduation.Repository
{
    using System.Collections.Generic;
    using Graduation.Models;

    /// <summary>
    /// Class holding repository and supprted functions.
    /// </summary>
    public class Repository
    {
        // AdarshSharma: Implementing IOC (S.O.L.I.D) principle, for future advancement
        public interface IGetData
        {
            dynamic GetData(int id);
        }

        public class GetRecords
        {
            public dynamic GetValues(IGetData get, int id)
            {
                return get.GetData(id);
            }
        }

        // AdarshSharma: Getting students records
        public class GetStudentValues : IGetData
        {
            public dynamic GetData(int id)
            {
                return GetStudents().Find(x => x.Id == id);
            }
        }

        // AdarshSharma: Getting Diploma Records
        public class getDiplomaValues : IGetData
        {
            public dynamic GetData(int id)
            {
                return GetDiplomas();
            }
        }

        // AdarshSharma; Getting Requirements Records
        public class getRequirementValues : IGetData
        {
            public dynamic GetData(int id)
            {
                return GetRequirements().Find(x => x.Id == id);
            }
        }

        /// <summary>
        /// Reterive specific Student info from diploma repo
        /// </summary>
        /// <param name="id">identity key</param>
        /// <returns>Student Model</returns>
        public static Student GetStudent(int id)
        {
            GetRecords gr = new GetRecords();
            GetStudentValues gsv = new GetStudentValues();
            Student student = gr.GetValues(gsv, id);
            return student;
        }

        /// <summary>
        /// Reterive specific Diploma info from diploma repo
        /// </summary>
        /// <param name="id">Identify</param>
        /// <returns>Diploma Model</returns>
        public static Diploma GetDiploma(int id)
        {
            GetRecords gr = new GetRecords();
            getDiplomaValues gdv = new getDiplomaValues();
            Diploma diploma = gr.GetValues(gdv, id);
            return diploma;
        }

        /// <summary>
        /// Reterive specific Requirement info from requirement repo
        /// </summary>
        /// <param name="id">Identify</param>
        /// <returns>Requirement Model</returns>
        public static Requirement GetRequirement(int id)
        {
            GetRecords gr = new GetRecords();
            getRequirementValues grv = new getRequirementValues();
            Requirement requirement = gr.GetValues(grv, id);
            return requirement;
        }

        /// <summary>
        /// Reterive specific Requirement info from requirement repo
        /// </summary>
        /// <param name="id">Identify</param>
        /// <returns>Requirement Model</returns>
        private static Diploma GetDiplomas()
        {
            return new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };
        }

        /// <summary>
        /// Get All Requirements from database
        /// </summary>
        /// <returns>Requirement list</returns>
        public static List<Requirement> GetRequirements()
        {
            List<Requirement> r = new List<Requirement>();
            r.Add(new Requirement { Id = 100, Name = "Math", MinimumMark = 50, Courses = new int[] { 1 }, Credits = 1 });
            r.Add(new Requirement { Id = 102, Name = "Science", MinimumMark = 50, Courses = new int[] { 2 }, Credits = 1 });
            r.Add(new Requirement { Id = 103, Name = "Literature", MinimumMark = 50, Courses = new int[] { 3 }, Credits = 1 });
            r.Add(new Requirement { Id = 104, Name = "Physichal Education", MinimumMark = 50, Courses = new int[] { 4 }, Credits = 1 });

            return r;
        }

        /// <summary>
        /// Get All Student info from database
        /// </summary>
        /// <returns>Student list</returns>
        private static List<Student> GetStudents()
        {
            List<Student> s = new List<Student>();
            s.Add(new Student
            {
                Id = 1,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
            });
            s.Add(new Student
            {
                Id = 2,
                Courses = new Course[]
                   {
                        new Course {Id = 1, Name = "Math", Mark = 80 },
                        new Course{Id = 2, Name = "Science", Mark = 80 },
                        new Course{Id = 3, Name = "Literature", Mark = 80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark = 80 }
                   }
            });
            s.Add(new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            });
            s.Add(new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            });

            return s;
        }
    }
}
