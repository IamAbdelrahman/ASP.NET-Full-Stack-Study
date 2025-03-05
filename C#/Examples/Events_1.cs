/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: Events_1.cs
 *  @brief This lab shows how to use an event handler.
 *
 *  @details: There is a publisher class that calculates a salary upon a certain
 * condition for employees to create an event that used by a subscriber class
 * to handle this event to show a message declares the name of employees whose
 * salaries have been calculated.
 *****************************************************************************/
 
internal class Employee
{
  public int Age { get; set; }
  public string ? Name { get; set; }
  public int BasicSalary { get; set; }
  public int Deduction { get; set; }
  public int Bonus { get; set; }
  public int DepartmentId { get; set; }
  public void DisplayDetails()
  {
    Console.WriteLine("ID: " + Age);
    Console.WriteLine("Name: " + Name);
  }
}

internal class SalaryCalculator
{
  public delegate bool ShouldCalculate(Employee e);
  public event EmployeeSalaryCalculatedEventHandler ?EmployeeSalaryCalculated;
  public delegate void EmployeeSalaryCalculatedEventHandler(Employee e, int salary);
  public void GetSalaryWithDelegate(List<Employee> employee, ShouldCalculate predicate)
  {
    foreach (var emp in employee)
    {
      if (predicate(emp) == true)
      {
        var salary = emp.BasicSalary + emp.Bonus - emp.Deduction;

        // Publish an Event
        EmployeeSalaryCalculated ?.Invoke(emp, salary);
      }
    }
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    var calculateSalary = new SalaryCalculator();

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

    // Handle an event
    calculateSalary.EmployeeSalaryCalculated += LogEmployeeSalary;
    calculateSalary.EmployeeSalaryCalculated += (employees, salary) => 
    Console.WriteLine($"Payslip sent to employee {employees.Name}");

    calculateSalary.GetSalaryWithDelegate(employees, e => e.BasicSalary > 8000);

  }

  private static void LogEmployeeSalary (Employee employee, int salary)
  {
    Console.WriteLine($"Salary of {employee.Name} is {salary}");
  }

}
