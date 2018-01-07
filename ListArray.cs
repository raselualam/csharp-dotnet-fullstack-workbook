using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // array of string
        string[] myArray = new string[3]; // index 0 , 1
        int[] myInt = new int[4];

        myArray[0] = "Erik";
        myArray[1] = "Austin";
        myArray[2] = "Texas";
        //......
        //myArray[20]= "something";

        //Console.WriteLine(myArray[2]);
        //Console.ReadLine();

        for (var i = 0; i < myArray.Length; i++)
        {
          //  Console.WriteLine(myArray[i]);
          //  Console.ReadLine();
        }

        //for loop on two dimension

        int[,] myNumberArray = new int[1,2];

        myNumberArray[0, 0] = 123;
        myNumberArray[0, 1] = 456;
        myNumberArray[0, 2] = 789;

        for (var x = 0; x < myNumberArray.Length; x++)
        {

        }

        //List

        List<string> myList = new List<string>();

        myList.Add("Erik");
        myList.Add("Zambrano"); //index 0,1
        myList[0] = "Eric";

        for (var y=0; y<myList.Count; y++)
        {

        }

        //Completed 
    }
}