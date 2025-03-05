/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: Dictionary.cs
 *  @brief This lab shows how to use dictionaries
 *
 *****************************************************************************/

  public static void Main(string[] args)
  {
    var dict = new Dictionary<string, string>(); 
    dict.Add("twitter", "12345678"); // You cannot add another value to that key
    if (!dict.ContainsKey("gmail"))
      dict.Add("gmail", "abcdefgh");
    Console.WriteLine(dict["gmail"]);

    bool isFound =  dict.TryGetValue("hotmail", out var value);
    Console.WriteLine(isFound);
    var keys = dict.Keys;
    foreach (var key in keys)
      Console.WriteLine(key);
    
    var values = dict.Values;
    foreach (var val in values)
      Console.WriteLine(val);
  }