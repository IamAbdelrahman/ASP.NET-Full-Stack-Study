using System;
public class Program
{
    public static void Main()
    {
        // Casting / Type Conversion
        int x = 10;
        float y = 10.5f;
        double z = 20.99;
        string str = "122";
        int parsedInt2 = Convert.ToInt32(str);
        bool sucess = int.TryParse(str, out int parsedInt);
        if (sucess)
        {
            Console.WriteLine("Parsing succeeded.");
            Console.WriteLine($"Parsed integer: {parsedInt}");
        }
        else
        {
            Console.WriteLine("Parsing failed.");
            Console.WriteLine($"Parsed integer: {parsedInt}");
        }

        // Implicit/Explicit conversion
        short a = 10;
        int b = a; // Implicit conversion from short to int
        short c = (short) b;
        Console.WriteLine($"Implicit conversion: {a} to {b}");

        // Boxing and Unboxing
        int num = 42;
        object obj = num; // Boxing: Converting value type to object type
        Console.WriteLine((int) obj + 1); // Unboxing: Converting object type back to value type

        // BitConversion
        var number = 256;
        var bytes = BitConverter.GetBytes(number);
        Console.WriteLine($"Bytes: {string.Join(", ", bytes)}");
        foreach (var byteValue in bytes)
        {
            var bitString = Convert.ToString(byteValue, 2).PadLeft(8, '0');
            Console.WriteLine(bitString);
        }
        Console.WriteLine("-----------------------------");
        var name = "Abdo";
        char[] letters = name.ToCharArray();
        foreach (var letter in letters)
        {
            var bitString = Convert.ToString(letter, 2).PadLeft(8, '0');
            var hexa = Convert.ToString(letter, 16).PadLeft(2, '0');
            int asciiValue = (int) letter;
            var output = $"Letter: {letter}, ASCII: {asciiValue}, Bits: {bitString}, Hex: {hexa}";
            Console.WriteLine(output);
        }
        Console.WriteLine("-----------------------------");

        string[] hexaValues = { "41", "62", "64", "6F" };
        var myName = "";
        foreach (var hexaValue in hexaValues)
        {
            int intValue = Convert.ToInt32(hexaValue, 16);
            char character = (char) intValue;
            myName += $"{character}";            
            Console.WriteLine($"Hex: {hexaValue}, Int: {intValue}, Char: {character}");
        }
        Console.WriteLine(myName);
        Console.WriteLine("-----------------------------");

        // Methods (Local Methods)
        bool isEven(int number) => number % 2 == 0;
        int ex = 4;
        if (isEven(ex))
        {
            Console.WriteLine($"{ex} is even.");
        }
        else
        {
            Console.WriteLine($"{ex} is odd.");
        }


    }

}
