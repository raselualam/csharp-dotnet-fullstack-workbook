using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static Dictionary<string, List<int>> stacks = new Dictionary<string, List<int>>()
    {
        { "a", new List<int>() {5, 4, 3, 2, 1} },
        { "b", new List<int>() {} },
        { "c", new List<int>() {} }
    };

    public static void Main()
    {
        do
        {
            PrintStacks();
            Console.WriteLine("Move start:");
            string start = Console.ReadLine();

            Console.WriteLine("Move ends:");
            string finish = Console.ReadLine();

            //check if the move is legal
            if(IsLegal(start, finish))
            {
                MovePiece(start, finish);
            }
            else
            {
                Console.WriteLine("That move was ilegal, try again");
            }
        } while (!CheckForWin());

        PrintStacks(); // One more time so the use can see all the block on top of pillar "c"
        Console.WriteLine("Congrats, you won!");

        Console.ReadLine();
    }

    public static bool CheckForWin()
    {
        // 3 - Check for win

        // We need to count the elements on
        // the "c" pillar

        if (stacks["a"].Count == 0 && stacks["b"].Count == 0)
            return true;

        return false;
    }

    public static void MovePiece(string start, string finish)
    {
        //  1 - Move a piece

        int lastElement = stacks[start].Last();

        // add lastElement into the finish pillar
        stacks[finish].Add(lastElement);

        // remove it from start pillar
        stacks[start].Remove(lastElement);
    }

    public static bool IsLegal(string start, string finish)
    {
        //  2 - Is it a legal move?

        // check for empty pillar - finish (List)
        if (stacks[finish].Count == 0)
            return true;

        // check for existing values on both pillars
        int lastNumberFromStart = stacks[start].Last();
        int lastNumberFromFinish = stacks[finish].Last();

        if (lastNumberFromStart < lastNumberFromFinish)
            return true;

        return false;
    }

    public static void PrintStacks()
    {
        string[] letters = new string[] { "a", "b", "c" };
        for (var i = 0; i < letters.Length; i++)
        {
            List<string> blocks = new List<string>();
            for (var j = 0; j < stacks[letters[i]].Count; j++)
            {
                blocks.Add(stacks[letters[i]][j].ToString());
            }
            Console.WriteLine(letters[i] + ": " + String.Join("|", blocks));
        }
    }
}