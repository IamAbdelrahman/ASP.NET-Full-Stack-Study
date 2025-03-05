/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: List.cs
 *  @brief This lab shows how to use Lists.
 *
 *****************************************************************************/

class Program 
{
  static void Main(string[] args)
  {
    // Strongly data type.
    List <string> list = new List<string>();
    list.Capacity = 2;
    list.Add("Abdelruhman");
    list.Add("Ibrahim");

    // Add/Remove more than one item.
    list.AddRange(new string[2] { "Mostafa", "Issam"});

    foreach (var name in list)
    {
      Console.WriteLine(name);
    }
    Console.WriteLine("------------");

    list.Remove("Ibrahim");

    int index = list.IndexOf("Mostafa");
    Console.WriteLine(index);

    index = list.IndexOf("Abdelruhman");
    Console.WriteLine(index);

    foreach (var name in list)
    {
      Console.WriteLine(name);
    }
    Console.WriteLine("------------");

    list.RemoveRange(0, 2);

    foreach (var name in list)
    {
      Console.WriteLine(name);
    }
    Console.WriteLine("------------");
    
    // Capacity is doubled.
    Console.WriteLine(list.Capacity);
  }
}

