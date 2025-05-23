class Program
{
  static void Main()
  {
    // Func<string, string, string> stringJoin = (str1, str2) => string.Concat(str1, str2);

    // // Let's create this code as a #pragma warning disable format
    // Expression<Func<string, string, string>> stringJoinExpr = (str1, str2) => string.Concat(str1, str2);

    // // Compile the code
    // var func = stringJoinExpr.Compile();
    // var result = func("Hello, World");
    // var result = stringJoinExpr.Compile()("Hello", "Everyone");

    List<int> h1 = [3, 2, 1, 1, 1];
    List<int> h2 = [4, 3, 2];
    List<int> h3 = [1, 1, 4, 1];
    Console.WriteLine(equalStacks(h1, h2, h3));
  }
  public static int equalStacks(List<int> h1, List<int> h2, List<int> h3)
  {
    int[] listSums = new int[3] { h1.Sum(), h2.Sum(), h3.Sum() };
    int height = 0;
    bool isEqual = false;
    int index = 0;
    Stack<int> h1_stack = new Stack<int>();
    Stack<int> h2_stack = new Stack<int>();
    Stack<int> h3_stack = new Stack<int>();
    for (int i = h1.Count - 1; i >= 0; i--)
      h1_stack.Push(h1[i]);
    for (int i = h2.Count - 1; i >= 0; i--)
      h2_stack.Push(h2[i]);
    for (int i = h3.Count - 1; i >= 0; i--)
      h3_stack.Push(h3[i]);

    while (true)
    {
      isEqual = CheckEqulaity(listSums, out height);
      if (isEqual)
      {
        return height;
      }
      else
      {
        if (h1_stack.Count == 0 || h2_stack.Count == 0 || h3_stack.Count == 0)
          return 0;
        GetMinIndex(listSums, out index);
        if (index == 1)
        {
          h2_stack.Pop();
          h3_stack.Pop();
        }
        else if (index == 2)
        {
          h1_stack.Pop();
          h3_stack.Pop();
        }
        else
        {
          h1_stack.Pop();
          h2_stack.Pop();
        }
        listSums[0] = h1_stack.Sum();
        listSums[1] = h2_stack.Sum();
        listSums[2] = h3_stack.Sum();

      }
    }

  }

  public static bool CheckEqulaity(int[] sums, out int height)
  {
    for (int i = 0; i < sums.Length; i++)
    {
      if (sums[0] != sums[i])
      {
        height = 0;
        return false;
      }
    }
    height = sums[0];
    return true;
  }

  public static void GetMinIndex (int[] arr, out int index)
  {
    index = 0;
    int min = arr.Min();
    for (int i = 0; i < arr.Length; i++)
    {
      if (arr[i] == min)
      {
        index = i + 1;
        return ;
      }
    }
  }
  

}