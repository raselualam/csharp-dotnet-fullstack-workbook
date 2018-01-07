using System;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("**** Checkpoint 1 ****");
        Console.WriteLine("**********************");
        Console.WriteLine("**********************");
        Console.Write("\n");

        Console.WriteLine("**** Problem 1 ****");
        NumbersDivisbleByThree();
        Console.WriteLine("**********************");
        Console.WriteLine("**********************");
        Console.Write("\n");

        Console.WriteLine("**** Problem 2 ****");
        KeepAddingUp();
        Console.WriteLine("**********************");
        Console.WriteLine("**********************");
        Console.Write("\n");

        Console.WriteLine("**** Problem 3 ****");
        Factorial();
        Console.WriteLine("**********************");
        Console.WriteLine("**********************");
        Console.Write("\n");

        Console.WriteLine("**** Problem 4 ****");
        GuessNumber();
        Console.WriteLine("**********************");
        Console.WriteLine("**********************");
        Console.Write("\n");

        Console.WriteLine("**** Problem 5 ****");
        MaxNumber();
        Console.WriteLine("**********************");
        Console.WriteLine("**********************");

        Console.ReadLine();
    }

    // 1. How many numbers between 1 and 100 are divisible by 3 
    public static void NumbersDivisbleByThree()
    {
        int count = 0;

        for (var i = 1; i <= 100; i++)
        {
            if (i % 3 == 0)
                count++;
        }

        Console.WriteLine($"There are {count} numbers between 1 and 100 that are divisible by 3");

    }

    // 2. continuously ask the user to enter a number or "ok"
    public static void KeepAddingUp()
    {
        bool keepAsking = true;
        int totalSum = 0;

        do
        {
            Console.WriteLine("Enter a number to be added");
            string input = Console.ReadLine();

            int inputAsNumber;

            if(int.TryParse(input, out inputAsNumber))
            {
                totalSum += inputAsNumber; // totalSum = totalSum + inputAsNumber
            }
            else if(input == "ok")
            {
                keepAsking = false;
            }

        } while (keepAsking);

        Console.WriteLine($"The numbers add up to {totalSum}");

    }

    // 3. Compute the factorial of the number
    public static void Factorial()
    {
        Console.WriteLine("What number you want know the factorial value?");
        int factorial = 1; // Not initialized with 0 since multipling any number by 0 is always 0 

        int input = int.Parse(Console.ReadLine());

        // for loop stops at 2 because multipling something by 1 gives the same value
        for (var i = input; i >= 2; i--) 
        {
            factorial *= i; // factorial = factorial * i;
        }

        Console.WriteLine($"{input}! = {factorial}.");
    }

    // 4.  Computer picks a random number between 1 and 10, user has 4 chances to guess it.
    public static void GuessNumber()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 11);

        int chances = 4;
        int tries = 0;
        bool guessIt = false;

        while(tries < chances && !guessIt)
        {
            Console.WriteLine("Guess the number I thought between 1 and 10");

            int input = int.Parse(Console.ReadLine());

            if(input == randomNumber)
            {
                guessIt = true;
            }
            else
            {
                tries++;
            }
        }

        if(guessIt)
        {
            Console.WriteLine("You won");
        }
        else
        {
            Console.WriteLine($"You lost, the number was {randomNumber}");
        }
    }

    // 5. Ask the user to enter a series of numbers separated by comma, find max number
    public static void MaxNumber()
    {
        Console.WriteLine("Provide a list of numbers separated by a comma and I will find the max number");

        string input = Console.ReadLine();

        int maxNumber = 0;
        string[] inputSplitted = input.Split(',');

        foreach(var s in inputSplitted)
        {
            int valueFromArray = int.Parse(s.Trim());

            if(valueFromArray > maxNumber)
            {
                maxNumber = valueFromArray;
            }
        }

        Console.WriteLine($"The max number typed is {maxNumber}");
    }
}