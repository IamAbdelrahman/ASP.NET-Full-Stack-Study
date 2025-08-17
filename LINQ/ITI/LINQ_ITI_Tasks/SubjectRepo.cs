using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_ITI_Tasks
{
    public class SubjectRepo
    {
        public static List<Subject[]> GetSubjects()
        {
            return new List<Subject[]>
                {
                    new Subject[]
                    {
                        new Subject { Code = 22, Name = "EF" },
                        new Subject { Code = 33, Name = "UML" }
                    },

                    new Subject[]
                    {
                        new Subject { Code = 22, Name = "EF" },
                        new Subject { Code = 34, Name = "XML" },
                        new Subject {Code = 25, Name = "JS"}
                    },

                    new Subject[]
                    {
                        new Subject {Code = 22, Name = "EF"},
                        new Subject {Code = 25, Name = "JS"}
                    },

                    new Subject[]
                    {
                        new Subject {Code = 33, Name = "UML"}
                    }
                };
        }
    }
}
