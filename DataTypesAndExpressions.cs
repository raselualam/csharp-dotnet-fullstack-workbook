using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        // 1. Write a C# program that takes two numbers as input, adds them together, 
        // and displays the result of that operation
        Console.WriteLine("First number:");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Second number:");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Result: " + firstNumber + secondNumber);

        // 2. Write a C# program that coverts yards to inches.
        // Knowing that 1 yard = 36 inch

        Console.WriteLine("How many yards do you want to conver?");
        int yards = int.Parse(Console.ReadLine());

        Console.WriteLine($"{yards} yards are equal to {yards * 36} inches");

        // 3. Create and define the variable people as true.
        var people = true;

        // 4. Create and define the variable f as false.
        bool f = false;

        // 5. Create and define the variable num to be a decimal.
        decimal num = 200.36m;

        //6. Display the product of num multiplied by itself.
        Console.WriteLine($"The decimal is {num} and multiplied by itself is equal to {num * num}");

        // 9. Convert the variable num to an int.
        // This can be done many ways - here are some
        int num2 = (int)num;
        int num3 = Convert.ToInt32(num);
        int num4 = Decimal.ToInt32(num);

        // leave this command at the end so your program does not close automatically
        Console.ReadLine();
    }
}