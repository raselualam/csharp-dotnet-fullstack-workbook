using System;

public class Program
{
    // possible letters in code
    public static char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

    // size of code
    public static int codeSize = 4;

    // number of allowed attempts to crack the code
    public static int allowedAttempts = 10;

    // number of tried guesses
    public static int numTry = 0;

    // test solution
    public static char[] solution = new char[] { 'a', 'b', 'c', 'd' };

    // game board
    public static string[][] board = new string[allowedAttempts][];


    public static void Main()
    {
        char[] guess = new char[4];
        bool shouldGameContinue = true;
        CreateBoard();

        while (shouldGameContinue)
        {
            DrawBoard();
            Console.WriteLine("Enter Guess:");
            guess = Console.ReadLine().ToCharArray();

            shouldGameContinue = !CheckSolution(guess) && !HasUserRunOutOfAttemps();
        }

        Console.ReadLine();
    }

    public static bool CheckSolution(char[] guess)
    {
        // 1 - Detect a correct solution

        string guessString = string.Join("", guess);
        string solutionString = string.Join("", solution);

        if (guessString == solutionString)
        {
            Console.WriteLine("Congrats, you guessed the secret code!");
            return true;
        }

        InsertCode(guess);
        return false;
    }

    public static string GenerateHint(char[] guess)
    {
        // 2 - Generate a hint

        // Clone the solution
        char[] solutionCloned = (char[])solution.Clone();

        // Determine correct "letter-locations" 
        int correctLetterLocations = 0;

        for (int i = 0; i < solutionCloned.Length; i++)
        {
            if (solutionCloned[i] == guess[i])
            {
                correctLetterLocations++;
                solutionCloned[i] = ' '; //By doing this we don't count again the same letter found in the next for loop
            }
        }

        // Determine correct "letters" 
        int correctLetters = 0;

        for (int i = 0; i < solutionCloned.Length; i++)
        {
            string clonedSolutionString = string.Join("", solutionCloned);

            int targetIndex = clonedSolutionString.IndexOf(guess[i]); //if no letter is found IndexOf return -1

            if (targetIndex > -1) //In other words if a letter was found
            {
                correctLetters++;
                solutionCloned[targetIndex] = ' ';
            }
        }

        // return hint string
        return $"{correctLetterLocations}-{correctLetters}";
    }

    public static void InsertCode(char[] guess)
    {
        // 3 - Add guess and hint to the board

        for (int i = 0; i < guess.Length; i++)
        {
            board[numTry][i] = guess[i].ToString();
        }

        board[numTry][4] = GenerateHint(guess);

        numTry++;
    }

    public static void CreateBoard()
    {
        for (var i = 0; i < allowedAttempts; i++)
        {
            board[i] = new string[codeSize + 1];
            for (var j = 0; j < codeSize + 1; j++)
            {
                board[i][j] = " ";
            }
        }
        return;
    }

    public static void DrawBoard()
    {
        for (var i = 0; i < board.Length; i++)
        {
            Console.WriteLine("|" + String.Join("|", board[i]));
        }

        return;
    }

    public static void GenerateRandomCode()
    {
        Random rnd = new Random();
        for (var i = 0; i < codeSize; i++)
        {
            solution[i] = letters[rnd.Next(0, letters.Length)];
        }
        return;
    }

    public static bool HasUserRunOutOfAttemps()
    {
        if (numTry < 10)
            return false;

        Console.WriteLine($"You ran out of turns! The solution was: {string.Join("", solution)}");
        return true;
    }
}