  /* Projection and Filtering (Select, Where, OfType).
  *  Sorting (OrderBy, OrderByDescending, ThenBy, ThenByDescending, Reverse).
  */

  public static void Main(string[] args)
  {
    List<int> numbers = new List<int> {1, 3, 2, 6, 5, 10, 9};

    // 1) Query Syntax
    var result = from number in numbers orderby number ascending
    where number > 2 select number;
    foreach(var number in result)
    {
      Console.WriteLine(number);
    }
    Console.WriteLine("--------------");

    // 2) Method Syntax
    var result2 = numbers.OrderBy(x => x).Where(x => x > 2);
    Console.WriteLine("--------------");
    foreach (var number in result2)
    {
      Console.WriteLine(number);
    }
    Console.WriteLine("--------------");

    // 3) Normal Approach
    numbers.Sort();
    foreach (var number in numbers)
    {
      if (number > 2)
        Console.WriteLine(number);
    }

    // This exercises show the Projection, Filtering, and Sorting.
    var employees = new List<Employee>
    {
      new ("Mohammed", 28, 8000),
      new ("Ahmed", 25, 1000),
      new ("Ahmed", 35, 6000),
      new ("Ahmed", 30, 4000),
      new Manager {EmpName = "Hossam", EmpAge = 33},
      new Contractor {EmpName = "Hassan", EmpAge = 40, EmpSalary = 9000},
      new Contractor {EmpName = "Khalid", EmpAge = 42, EmpSalary = 7500}
    };

    // 1) Query Syntax
    var query = from employee in employees
                orderby employee.EmpName, employee.EmpAge,
    employee.EmpSalary
                select employee;
    foreach (var employee in query)
    {
      Console.WriteLine($"{employee.EmpName}, {employee.EmpAge}, {employee.EmpSalary}");
    }
    Console.WriteLine("--------------");

    // 2) Method Syntax
    var result = employees.OfType<Manager>().OrderBy(x => x.EmpName).ThenBy(x => x.EmpAge);
    //.Select(x  => new {x.EmpName, x.EmpAge}); // Anonymous type
    foreach (var employee in result)
    {
      Console.WriteLine($"{employee.EmpName}, {employee.EmpAge}, {employee.EmpSalary}");
    }
                
  }

    