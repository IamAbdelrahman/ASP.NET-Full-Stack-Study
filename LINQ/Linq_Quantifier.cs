public class Program
{
  /*
  * Quantifiers (All, Any, Contains).
  */ 

  public static void Main(string[] args)
  {
    var numbers = new List<int> {0, 7, 1, 9, 2, 4, 3, 5, 8, 6, 10};

    // 1) Query Syntax
  
    Console.WriteLine("-");

    // 2) Method Syntax
    var resultContains = numbers.Contains(6);
    Console.WriteLine(resultContains);  // True
    var resultAll = numbers.All(x => x > 0);
    Console.WriteLine(resultAll);       // False
    var resultAny = numbers.Any(x => x > 0);
    Console.WriteLine(resultAny);       // True
    Console.WriteLine("--------------");
    // 3) Normal Approach
    bool resultContains2 = false;
    foreach (var number in numbers)
    {
      if (number == 6 )
      {
        resultContains2 = true;
        break;
      }
    }
    Console.WriteLine(resultContains2);

  }
}