namespace LINQ_Demo
{
    internal class Program
    {
        static void Main()
        {
            //Run_SelectQuery();
            //Run_SelectWithAnonymousType();
            //Run_SelectQueryMethod();
            //Run_SelectQueryMethodWithAnonymousType();
            //Run_Select_DistinctQuery();
            //Run_FirstQuery();
            //Run_LastQuery();
            //Run_AggregateQuery();
            //Run_SingleQuery();
            //Run_OrderBy();
            //Run_Select();
            //Run_Partition();
            Run_GroupBy();
        }
        static void Run_SelectQuery()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = from n in numbers
                              where n % 2 == 0
                              select n;
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }
        static void Run_SelectWithAnonymousType()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = from n in numbers
                              where n % 2 == 0
                              select new { Number = n };
            foreach (var n in evenNumbers)
            {
                //Console.WriteLine(n); This will use ToString() method of the anonymous type
                Console.WriteLine(n.Number);
            }
        }
        static void Run_SelectQueryMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = numbers.Where(n => n % 2 == 0).Select(n => n);
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number);
            }
        }
        static void Run_SelectQueryMethodWithAnonymousType()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = numbers.Where(n => n % 2 == 0).Select(n => new { Even = n });
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number.Even);
            }
        }
        static void Run_Select_DistinctQuery()
        {
            List<string> names = new List<string> { "Alice", "Bob", "alice", "Charlie", "BOb" };
            var result = names.Select(n => n.ToLower()).Distinct();
            foreach (var name in result)
            {
                Console.WriteLine(name);
            }
        }
        static void Run_FirstQuery()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var firstEvenNumber = numbers.FirstOrDefault(n => n % 2 == 0);
            var fisrtEvenNumberAndGreaterThanTen = numbers.FirstOrDefault(n => n % 2 == 0 && n > 10);
            Console.WriteLine(firstEvenNumber); // Output: 2
            Console.WriteLine(fisrtEvenNumberAndGreaterThanTen);
            var employees = EmpRepo.GetEmployees();
            var firstEmployee = employees.First();
            Console.WriteLine(firstEmployee);
        }
        static void Run_LastQuery()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var lastEvenNumber = numbers.LastOrDefault(n => n % 2 == 0);
            var lastEvenNumberAndGreaterThanTen = numbers.LastOrDefault(n => n % 2 == 0 && n > 10);
            Console.WriteLine(lastEvenNumber); // Output: 10
            Console.WriteLine(lastEvenNumberAndGreaterThanTen);
            // output: 0 (default value for int, since no number matches the condition)
        }
        static void Run_AggregateQuery()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var min = numbers.Min();
            var max = numbers.Max();
            Console.WriteLine($"Min is {min} and Max is {max}");
            var employees = EmpRepo.GetEmployees();
            var minSalary = employees.Min(e => e.Salary);
            Console.WriteLine($"The minium salary of employees is {minSalary}");
            // Compare between employees by name and salary
            var emp = employees.Min(new EmployeeComparer());
            Console.WriteLine(emp);
            var kids = ChildRepo.GetChildren();
            var kid = kids.Min(new ChildComparer());
            Console.WriteLine(kid);
        }
        static void Run_SingleQuery()
        {
            var kids = ChildRepo.GetChildren();
            //try
            //{
            //    var singleKid = kids.Single(k => k.Id == 1);
            //    Console.WriteLine($"Single Kid: {singleKid.Name}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}
            //finally
            //{
            //    Console.WriteLine("Single query completed.");
            //}
            List<int> numbers = new List<int> { 1, 3 };
            var singleNumber = numbers.Single(n => n % 2 == 0); // This will work
            Console.WriteLine(singleNumber);
            //var singleKid = kids.SingleOrDefault(k => k.Id == 1);
            //Console.WriteLine(singleKid);
        }
        static void Run_OrderBy()
        {
            var employees = EmpRepo.GetEmployees();
            var orederedEmployees = employees.OrderBy(e => e.Name).ThenBy(e => e.Salary);
            foreach (var employee in orederedEmployees)
            {
                Console.WriteLine(employee);
            }
        }
        static void Run_Select()
        {
            var fathers = FatherRepo.GetFathers();
            var fathersNames = fathers.Select(f => f.Name);
            foreach (var name in fathersNames)
            {
                Console.WriteLine(name);
            }
            var kidsNames = fathers.Select(f => f.Kids.Select(k => k.ChildName));
            foreach (var names in kidsNames)
            {
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            }
            // Combining fathers and kids using SelectMany
            var kids = fathers.SelectMany(f => f.Kids, (fathers, kids) => new { fathers.Name, kids.ChildName });
            foreach (var kid in kids)
            {
                Console.WriteLine(kid);
            }
        }
        static void Run_Partition()
        {
            var childern = ChildRepo.GetChildren();
            //var result = childern.Skip(2);
            //var result = childern.Take(2);
            var employees = EmpRepo.GetEmployees();
            var result = employees.TakeWhile(e => e.Salary != 3158);
            foreach (var child in result)
            {
                Console.WriteLine(child);
            }
        }
        static void Run_GroupBy()
        {
            var children = ChildRepo.GetChildren();
            var result = children.GroupBy(c => c.FavoriteColor);
            foreach (var group in result)
            {
                Console.WriteLine($"Color: {group.Key}");
                foreach (var child in group)
                {
                    Console.WriteLine(child);
                }
                Console.WriteLine("-------------------------");
            }
        }
    }
}
