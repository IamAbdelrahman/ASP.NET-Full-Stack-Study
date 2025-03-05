/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - CSharpFundamentalsCourse by M.ElMahdy
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: Enums.cs
 *  @brief This lab shows how to use enums.
 *
 *  @details: There is an attribute of [Flags] to use enums with an allowance of
 * combining multiple values into a single variable using bitwise operators 
 *****************************************************************************/

class Program
{
  [Flags]
  public enum WeekDays
  {
    None = 0,
    Saturday = 1,
    Sunday = 2,
    Monday = 4,
    Tuesday = 8,
    Wednesday = 16,
    Thursday = 32,
    Friday = 64,
  }
 
  public static void Main(string[] args)
  {
    WeekDays weekEnd = WeekDays.Saturday | WeekDays.Friday;
    WeekDays weekWeekDays = WeekDays.Saturday | WeekDays.Sunday | WeekDays.Monday | WeekDays.Tuesday | WeekDays.Wednesday | WeekDays.Thursday | WeekDays.Friday;
    WeekDays workWeekDays = weekWeekDays & ~weekEnd;
    WeekDays friday = weekEnd ^ WeekDays.Saturday;
    bool isFriday = friday == WeekDays.Friday;
    Console.WriteLine($"{isFriday}");
  }
}

