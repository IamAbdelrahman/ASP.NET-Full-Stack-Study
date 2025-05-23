public class Program
{
  /*
  * Partitioning (Skip, SkipWhile, Take, TakeWhile, Chunk).
  */ 

  public static void Main(string[] args)
  {
    var numbers = new List<int> {-1, 0, 1, 7, 9, 2, 4, 3, 5, 8, 6, 10};

    // 1) Query Syntax

    // 2) Method Syntax
    var result = numbers.SkipWhile(x => x <= 7);
    foreach (var number in result)
    {
      Console.WriteLine(number);
    }
    Console.WriteLine("-------");
    // 3) Normal Approach
    bool check = false;
    for (int i = 0; i < numbers.Count; i++)
    {
      if (numbers[i] <= 7 && check == false) continue;
      else 
      {
        Console.WriteLine(numbers[i]);
        check = true;
      }
    }

  }
}
  public static void Main(string [] args)
  {
    var numbers = new List<int> {0, 7, 1, 9, 2, 4, 3, 5, 8, 6, 10};

    // 1) Query Syntax

    // 2) Method Syntax
    var result = numbers.Skip(6).Take(4);
    foreach (var number in result)
    {
      Console.WriteLine(number);
    }
    Console.WriteLine("-------");
    // 3) Normal Approach
    int count = 4;
    for (int i = 0; i < numbers.Count; i++)
    {
      if (i < 6)  continue;
      else
      {
        Console.WriteLine(numbers[i]);
        count--;
      }
       Console.WriteLine(numbers[i]);
    }
}

  public static void Main(string[] args)
  {
    var numbers = new List<int> {-1, 0, 1, 7, 9, 2, 4, 3, 5, 8, 6, 10};

    // 1) Query Syntax

    // 2) Method Syntax
    var chunks = numbers.Chunk(4);
    foreach (var chunk in chunks)
    {
      foreach (var item in chunk)
      {
        Console.Write(item + " ");
      }
      Console.WriteLine("---------");
    }
    Console.WriteLine("-------");
    // 3) Normal Approach
    // - It's hard to do.

  }