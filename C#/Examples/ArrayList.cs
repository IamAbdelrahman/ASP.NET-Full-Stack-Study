/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: ArrayList.cs
 *  @brief This lab shows how to use ArrayLists
 *
 *****************************************************************************/

using System.Collections;
namespace myfirstApp;

class Program 
{
  static void Main(string[] args)
  {
    ArrayList list = new ArrayList();
    list.Add(0);
    list.AddRange(new float[3] {1.1f, 2.2f, 3.3f}); 
    list.Add("True");
    list.Add(false);
    foreach (var item in list)
    {
      Console.WriteLine(item);
    }

    list.Remove(0);
    list.RemoveAt(1);
    Console.WriteLine("--------------");
    foreach (var item in list)
    {
      Console.WriteLine(item);
    }

    ArrayList numbers = new ArrayList();
    numbers.AddRange(new int[3] {1, 2, 3}); // boxing
    Console.WriteLine("--------------");
    foreach (var item in numbers)
    {
      Console.WriteLine((int) item * 2); // unboxing
    }
  }
}

