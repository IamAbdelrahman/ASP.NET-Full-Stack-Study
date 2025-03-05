/******************************************************************************
 * Copyright (C) 2025 by Abdelrahman Kamal - .NET Full Stack Foundation by Coursera
 *****************************************************************************/

/*****************************************************************************
 * FILE DESCRIPTION
 * ----------------------------------------------------------------------------
 *  @file: Events_2.cs
 *  @brief This lab shows how to use an event handler.
 *
 *  @details: There is a publisher class that calculates the sum of two input numbers
 * and raise an event, if the result is an odd, and the subscriber logs a message
 * into the console after figuring out the odd number.
 *****************************************************************************/

internal class EventExample
{
  // Declare a Delegate 
  public delegate void OddNumberEventHandler();
  // Declare an Event
  public event OddNumberEventHandler ?OddNumberFound;

  public void Add()
  {
    int num1 = 0, num2 = 0, result = 0;
    num1 = int.Parse(Console.ReadLine());
    num2 = int.Parse(Console.ReadLine());
    result = num1 + num2;
    if (result % 2 != 0 && OddNumberFound != null)
      // Raise an Event
      OddNumberFound?.Invoke();
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    EventExample events = new EventExample();
    events.OddNumberFound += EventMessage;
    events.OddNumberFound += () => Console.WriteLine("Hello, from lambda expression!");
    events.Add();
  }

  static void EventMessage()
  {
    Console.WriteLine("Event is Executed: Odd Number");
  }
}
