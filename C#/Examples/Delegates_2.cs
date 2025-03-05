/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: Delegates_2.cs
 *  @brief This lab shows how to use delegates.
 *
 *  @details: There is an employee class and we want to calculate the salary of 
 * an employee, but under one condition. So we do this without the concept of delegation
 * and with using that concept by utilizing the lambda expression.
 *****************************************************************************/

public class Employee
{
  public string Name { get; set; }
  public int BasicSalary { get; set; }
  public int Deduction { get; set; }
  public int Bonus { get; set; }
}

class Program
{
  public delegate bool ShouldCalculate(Employee e);

  static void Main(string[] args)
  {
    List<Employee> employees = new List<Employee>();
    for (int i = 0; i < 100; i++)
    {
      employees.Add(new Employee()
      {
        Name = $"Employee{i + 1}",
        BasicSalary = Random.Shared.Next(1000, 10001),
        Deduction = Random.Shared.Next(0, 501),
        Bonus = Random.Shared.Next(0, 1001)
      });
    }
    GetSalaryWithoutDelegate(employees, 2000);
    Console.WriteLine("-----------------------------");
    GetSalaryWithDelegate(employees, e => e.BasicSalary > 2000);
  }

  static void GetSalaryWithoutDelegate(List<Employee> list, int maxSalary)
  {
    foreach (var emp in list)
    {
      var salary = emp.BasicSalary + emp.Bonus - emp.Deduction;
      if (emp.BasicSalary <= maxSalary)
      {
        Console.WriteLine($"Salary of {emp.Name} is {salary}");
      }
    }
  }

  static void GetSalaryWithDelegate(List<Employee> employee, ShouldCalculate predicate)
  {
    foreach (var emp in employee)
    {
      if (predicate(emp) == true)
      {
        var salary = emp.BasicSalary + emp.Bonus - emp.Deduction;
        Console.WriteLine($"Salary of {emp.Name} is {salary}");
      }
    }
  }
}