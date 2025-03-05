/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - .NET Full Stack Foundation by Coursera
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: LambdaExpressions.cs
 *  @brief This example shows you how to use expression lambda and statement lambda.
 *
 *  
 *****************************************************************************/

namespace CSharpLabs;
using System;

class Program
{
  static void Main()
  {
    // Expression Lambda
    var number = new[] {2, 4, 6, 8, 1, 3, 5, 5, 7};
    var count = number.Count (x => x == 5);
    Console.WriteLine(count);

    // Statement Lambda
    List<int> numbers = new List<int> {2, 4, 6, 8, 1, 3, 5, 5, 7};
    var counts = numbers.Count(x => {return x == 5;});
    Console.WriteLine(counts);
  }
}