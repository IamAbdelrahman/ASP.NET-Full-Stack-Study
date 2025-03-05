/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: GeneratePassword.cs
 *  @brief This file shows how to generate a password randomly using a string
 * contains all characters and digits
 *****************************************************************************/

namespace CSharpLabs.PassWordManager;
using System.Text;

public class GeneratePassword
{
  public StringBuilder sb = new StringBuilder();
  public string GetRandomPassword()
  {
    int size = 8;
    string allChars = EncryptionUtility._orderedChars;
    Random rand = new Random();
    while (size > 0)
    {
      sb.Append(allChars[rand.Next(allChars.Length)]);
      size--;
    }
    return sb.ToString();
  }
}
