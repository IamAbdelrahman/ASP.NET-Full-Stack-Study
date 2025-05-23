
public class Program
{
  /*
  * Joins (Join, GroupJoin).
  */

  public static void Main(string[] args)
  {
    var departments = new List<Department>
    {
      new (1, "HR"),
      new (2, "IT"),
      new (3, "Finance"),
      new (4, "Development")
    };
    var employees = new List<Employee>
    {
      new ("Mohammed Tarek", 28, 8000, 1),
      new ("Omar Khalid", 36, 9000, 1),
      new ("Ahmed Adel", 25, 1000, 2),
      new ("Ahmed Hatem", 35, 6000, 3),
      new ("Ahmed Hossam", 30, 4000, 4)
    };
    // 1) Method Syntax - Join
    var query = from employee in employees
                join department in departments on employee.DepartmentId equals department.Id
                select new { EmployeeName = employee.Name, DepartmentName = department.Name };
    foreach (var result in query)
    {
      Console.WriteLine($"{result.EmployeeName}: {result.DepartmentName}");
    }

    Console.WriteLine("---------------------");
    // 2) Method Syntax
    var query2 = employees
    .Join(departments, x => x.DepartmentId, x => x.Id
    , (e, d) => new { EmployeeName = e.Name, DepartmentName = d.Name });
    foreach (var record in query)
    {
      Console.WriteLine($"{record.EmployeeName} @ {record.DepartmentName}");
    }

    Console.WriteLine("---------------------");

    // 2) Method Syntax - GroupJoin
    // Each department gets a group of matching employees.
    var query3 = departments
    .GroupJoin(employees, x => x.Id, x => x.DepartmentId
    ,(d, employeesGroup) => new
    {
      DepartmentName = d.Name,
      Employees = employeesGroup.Select(x => x.Name).ToList()
    });

    foreach (var item in query3)
    {
      Console.WriteLine($"{item.DepartmentName}:-");
      Console.WriteLine(item.Employees.Any() ? string.Join(",", item.Employees): "None");
    }

  }
}


