public class Program
{
  /*
  * Set Operations (Distinct, DistinctBy, Except, ExceptBy, InterSect, InterSectBy, Union, UnionBy).
  */

  public static void Main(string[] args)
  {
    var numbers = new List<int> { -1, 0, 1, 7, 9, 2, 4, 3, 5, 8, 6, 10, 1, 0, -1 };
    var result = numbers.Distinct().OrderBy(x => x);
    foreach (var number in result)
    {
      Console.WriteLine(number);
    }
    Console.WriteLine("------------------");
    var employees = new List<Employee>
    {
      new ("Mohammed", 28, 8000),
      new ("Ahmed", 28, 8000),
      new ("Ahmed", 35, 6000),
      new ("Ahmed", 30, 4000),
      new Manager {EmpName = "Hossam", EmpAge = 33},
      new Contractor {EmpName = "Hassan", EmpAge = 40, EmpSalary = 9000},
      new Contractor {EmpName = "Khalid", EmpAge = 42, EmpSalary = 7500}
    };
    var query = employees.DistinctBy(x => x.EmpName);
    foreach (var employee in query)
    {
      Console.WriteLine($"{employee.EmpName}, {employee.EmpAge}, {employee.EmpSalary}");
    }

  }
    var numbers = new List<int> { -1, 0, 1, 7, 9, 2, 4, 3, 5, 8, 6, 10, 1, 0, -1 };
    var secondList = new List<int> { -1, 0, 1, 7, 9 , 100, 0};
    // var query = numbers.Except(secondList).OrderBy(x => x);
    // foreach (var number in query)
    // {
    //   Console.WriteLine(number);
    // }
    // Console.WriteLine("------------------");
    // var query = numbers.Intersect(secondList).OrderBy(x => x);
    // foreach (var number in query)
    // {
    //   Console.WriteLine(number);
    // }
    // Console.WriteLine("------------------");
    // var query = numbers.Union(secondList).OrderBy(x => x);
    // foreach (var number in query)
    // {
    //   Console.WriteLine(number);
    // }
    // Console.WriteLine("------------------");
}