using System.IO.Pipes;

namespace LINQ_ITI_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Run_Query1();
            //Run_Query2();
            Run_Query3();
        }

        /// <summary>
        /// Display numbers without any repeated Data and sorted
        /// </summary>
        static void Run_Query1()
        {
            Print("Query One");
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            var q = numbers.Distinct().OrderBy(x => x).ToList();
            foreach (var n in q)
            {
                Console.WriteLine($"Number {n} - Multiply {n * n}");
            }
        }

        /// <summary>
        /// Select names with length equal 3.
        /// Select names that contains “a” letter (Capital or Small )then sort them by length
        /// Display the first two names
        /// </summary>
        static void Run_Query2()
        {
            Print("Query Two");
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };
            var q1 = names.Where(n => n.Length == 3).Select(n => n).ToList();
            foreach (var name in q1)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("--------------------");

            var q2 = names.Where(n => n.Contains("a") || n.Contains("A")).OrderBy(n => n.Length).ToList();
            foreach (var name in q2)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("--------------------");

            var q3 = names.Take(2);
            foreach (var name in q3)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// 1- Display Full name and number of subjects for each student
        /// 2- Write a query which orders the elements in the list by FirstName Descending 
        /// then by LastName Ascending and result of query displays only first names 
        /// and last names for the elements in list
        /// 3- Display each student and student’s subject as follow
        /// </summary>
        static void Run_Query3()
        {
            Print("Query Three");
            var students = StudentRepo.GetStudents();
            var q1 = students.Select(s =>
            new
            {
                FullName = s.FirstName + " " + s.LastName,
                Subjects = s.Subjects.Length
            });
            foreach (var s in q1)
            {
                Console.WriteLine($"Full Name {s.FullName} - Number of subject is {s.Subjects}");
            }
            Console.WriteLine("---------------------");

            var q2 = students.OrderByDescending(s => s.FirstName).
                ThenBy(s => s.LastName).
                Select(s => s.FirstName +" "+ s.LastName);
            foreach(var name in q2)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("---------------------");

            var q3 = students.SelectMany(s => s.Subjects.Select(sub =>
            new
            {
                FullName = s.FirstName +" " + s.LastName,
                SubjectName = sub.Name
            }
            ));
            foreach (var s in q3)
            {
                Console.WriteLine($"Full Name is {s.FullName} - Subjects are {s.SubjectName}");
            }
            Console.WriteLine("---------------------");

            var q4 = students.GroupBy(s => s.FirstName + " " + s.LastName);
            string subName = "";
            foreach (var group in q4)
            {
                foreach(var s in group)
                {
                    Console.WriteLine(group.Key);
                    foreach (var sub in s.Subjects)
                    {
                        Console.WriteLine(sub.Name);
                    }
                }
            }
        }
        static void Print(string title)
        {
            Console.WriteLine();
            Console.WriteLine("┌───────────────────────────────────────────────────────┐");
            Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
            Console.WriteLine("└───────────────────────────────────────────────────────┘");
            Console.WriteLine();
        }
    }
}
