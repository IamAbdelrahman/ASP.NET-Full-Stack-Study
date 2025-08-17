using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_ITI_Tasks
{
    public class StudentRepo
    {
        public static IEnumerable<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Abdo",
                    LastName = "Kamal",
                    Subjects = SubjectRepo.GetSubjects()[0]
                },

                new Student()
                {
                    Id = 2,
                    FirstName = "Mona",
                    LastName = "Galal",
                    Subjects = SubjectRepo.GetSubjects()[1]
                },

                new Student()
                {
                    Id = 3,
                    FirstName = "Yara",
                    LastName = "Yusuf",
                    Subjects = SubjectRepo.GetSubjects()[2]
                },

                new Student()
                {
                    Id = 4,
                    FirstName = "Ali",
                    LastName = "Hossam",
                    Subjects = SubjectRepo.GetSubjects()[3]
                }

            };
        }
    }
}
