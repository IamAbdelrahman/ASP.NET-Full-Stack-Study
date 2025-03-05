/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: App.cs
 *  @brief This file declares how the application runs as it asks the user 
 *  to select an option (list, add, change, get, delete a passoword or quit the app)
 *
 *****************************************************************************/

using System.Text;

namespace CSharpLabs.PassWordManager;

public class App
{
  private static readonly Dictionary<string, string> _passwordEntries = new();
  public static void Run()
  {
    ReadPasswords();
    while (true)
    {
      Console.WriteLine("Please, select an option: ");
      Console.WriteLine("1. List all passwords");
      Console.WriteLine("2. Add/Change a password");
      Console.WriteLine("3. Get a password");
      Console.WriteLine("4. Delete a password");
      Console.WriteLine("0. Quit the program");

      var selectedOption = Console.ReadLine();
      switch (selectedOption)
      {
        case "1":
          ListAllPasswords();
          break;
        case "2":
          AddOrChangePassword();
          break;
        case "3":
          GetPassword();
          break;
        case "4":
          DeletePassword();
          break;
        case "0":
          return;
        default:
          Console.WriteLine("Invalid Option");
          break;
      }
      Console.WriteLine("-------------------------------------------");
    }
  }

  private static void ReadPasswords()
  {
    if (File.Exists("passwords.txt"))
    {
      var passwordLine = File.ReadAllText("passwords.txt");
      foreach (var line in passwordLine.Split(Environment.NewLine))
      {
        if (!string.IsNullOrEmpty(line))
        {
          //website=password
          var equalIndex = line.IndexOf(":");
          var appName = line.Substring(0, equalIndex);
          var password = line.Substring(equalIndex + 1);
          _passwordEntries.Add(appName, EncryptionUtility.Decrypt(password));
        }
      }

    }
  }
  private static void SavePassword()
  {
    var sb = new StringBuilder();
    foreach (var entry in _passwordEntries)
      sb.AppendLine($"{entry.Key}:{EncryptionUtility.Encrypt(entry.Value)}");
    File.WriteAllText("passwords.txt", sb.ToString());
  }

  private static void DeletePassword()
  {
    Console.Write("Please, enter your website name: ");
    var appName = Console.ReadLine();
    if (_passwordEntries.ContainsKey(appName))
      _passwordEntries.Remove(appName);
    else
      Console.WriteLine("Password is not found");
    SavePassword();
  }

  private static void GetPassword()
  {
    Console.Write("Please, enter your website name: ");
    var appName = Console.ReadLine();
    if (_passwordEntries.ContainsKey(appName))
      Console.WriteLine($"Your password is: {_passwordEntries[appName]}");
    else
      Console.WriteLine("Password is not found");
  }

  private static void AddOrChangePassword()
  {
    Console.Write("Please, enter your website name: ");
    var appName = Console.ReadLine();
    Console.WriteLine("Please, select an option for your password.");
    Console.WriteLine("1. Enter your own password.");
    Console.WriteLine("2. Generate a strong password");
    var selectedOption = Console.ReadLine();
    string password = "";
    if (selectedOption == "1")
    {
      Console.Write("Please, enter your password: ");
      password = Console.ReadLine();
    }
    else if (selectedOption == "2")
    {
      var obj = new GeneratePassword();
      password = obj.GetRandomPassword();
    }

    if (_passwordEntries.ContainsKey(appName))
      _passwordEntries[appName] = password;
    else
      _passwordEntries.Add(appName, password);
    SavePassword();
  }

  private static void ListAllPasswords()
  {
    foreach (var password in _passwordEntries)
    {
      Console.WriteLine($"{password.Key}:{password.Value}");
    }
  }
}
