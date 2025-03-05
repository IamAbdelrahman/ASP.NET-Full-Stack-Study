/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: EncryptionUtility.cs
 *  @brief This file shows how to encrypt a password by using Caesar Cipher algorithm
 *
 *****************************************************************************/

namespace CSharpLabs.PassWordManager;
using System.Text;
public class EncryptionUtility
{
  public static readonly string _orderedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
  static readonly string _shuffledChars = "h4MKJ5xaqB2yYXTt0ZAsGWC7m6RLvzN1H8P9f3bFdDVuESolIkQiwOUpgcenA";
  public static string Encrypt(string password)
  {
    var sb = new StringBuilder();
    foreach(var ch in password)
    {
      var charIndex = _orderedChars.IndexOf(ch);
      sb.Append(_shuffledChars[charIndex]);
    }
    return sb.ToString();
  }

  public static string Decrypt(string password)
  {
    var sb = new StringBuilder();
    foreach (var ch in password)
    {
      var charIndex = _shuffledChars.IndexOf(ch);
      sb.Append(_orderedChars[charIndex]);
    }
    return sb.ToString();
  }
}
