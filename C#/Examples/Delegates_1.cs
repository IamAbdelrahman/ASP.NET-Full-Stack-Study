/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: Delegates_1.cs
 *  @brief This lab shows how to use delegates.
 *
 *  @details: There is a delegate object that takes two int as parameters and
 * return int, and we pass some methods that take and return the same parameters
 * of the delegate object to be pointed to by that object. In addition to using
 * the multicasting feature of delegate to point to more than one method.
 *****************************************************************************/

class Program
{
  public delegate int CalculateDelegate(int num1, int num2);
 
  static void Main(string[] args)
  {
    Console.WriteLine("Without Delegation");
    int x = 10, y = 2;
    char[] operators = new char[] { '+', '-', '*', '/' };
    foreach (var op in operators)
    {
      Console.WriteLine(CalculateWithoutDelegate(x, y, op));
    }
    Console.WriteLine("--------------------");

    Console.WriteLine("With Delegation");
    CalculateWithDelegate(x, y, delegate (int x, int y) { return x + y; });  // Anonymous delegates
    CalculateWithDelegate(x, y, (int x, int y) => x * y);                    // Lambda expression
    CalculateWithDelegate(x, y, (x, y) => x - y);
    CalculateWithDelegate(x, y, (x, y) => x % y);
    CalculateWithDelegate(x, y, Div);
    Console.WriteLine("--------------------");

    Console.WriteLine("With MultiCasting Delegation");
    CalculateDelegate dlg = null;
    dlg = Sum;
    dlg += Sub; 
    dlg += Mul;
    CalculateWithDelegate(2, 3, dlg); // Output = 2 * 3 = 6
    dlg -= Mul;
    CalculateWithDelegate(2, 3, dlg); // Output = 2 - 3 = -1

  }

  static int CalculateWithoutDelegate(int num1, int num2, char op)
  {
    int result = 0;
    switch (op)
    {
      case '+':
        result = Sum(num1, num2);
        break;
      case '-':
        result = Sub(num1, num2);
        break;
      case '/':
        result = Div(num1, num2);
        break;
      case '*':
        result = Mul(num1, num2);
        break;
      default:
        break;
    }
    return result;
  }

  static void CalculateWithDelegate(int num1, int num2, CalculateDelegate dlg)
  {
    int result = dlg(num1, num2);
    Console.WriteLine(result);
  }

  static int Sum(int n1, int n2)
  {
    Console.WriteLine("Sum");
    return (n1 + n2);
  }

  static int Div(int n1, int n2)
  {
    try
    {
      Console.WriteLine("Div");
      return (n1 / n2);
    }
    catch (DivideByZeroException ex)
    {
      Console.WriteLine(ex.Message);
      return 0;
    }
  }

  static int Sub(int n1, int n2)
  {
    Console.WriteLine("Sub");
    return (n1 - n2);
  }
  
  static int Mul(int n1, int n2)
  {
    Console.WriteLine("Mul");
    return (n1 * n2);
  }

}
