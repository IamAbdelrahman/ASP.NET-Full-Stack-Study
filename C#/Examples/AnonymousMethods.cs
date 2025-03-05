/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - .NET Full Stack Foundation by Coursera
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: AnonymousMethods.cs
 *  @brief This lab shows how to use anonymous methods.
 *
 *  @details: An anonymous method accesses variables outside its scope, and
 *  it uses parameters too to add them together and returns their result.
 *****************************************************************************/

public delegate int Add (int a, int b);
public class Program
{
  public static void Main(string[] args)
  {
    string message = "Hello, This is Add method";
    Add add = delegate (int x, int y)
    {
      Console.WriteLine(message);
      return (x + y);
    };
    int result = add(4, 5);
    Console.WriteLine(result);
  }
}