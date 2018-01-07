using System;
using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        // create a new instance of the class Timer
        // creating an object 
        Timer myTimer = new Timer();
        bool continueAsking = true;
        myTimer.DoNothing();

        do
        {
            Console.WriteLine("What do you want to do?"); // "0" to start, "1" to stop, "x" to exit

            var input = Console.ReadLine();

            if (input == "0")
            {
                //try catch
                try
                {
                    myTimer.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (input == "1")
            {
                myTimer.Stop();
                Console.WriteLine($"The time was {myTimer.StopWatch.Elapsed}");
            }

            if (input == "x")
            {
                continueAsking = false;
            }
        } while (continueAsking);
    }
}

public class Timer : Clock
{
    // define properties
    public bool IsTimerWorking { get; set; }
    public Stopwatch StopWatch { get; set; }

    // variable
    string something = "something";

    // define methos - this is what the class do

    public void Start()
    {
        if (IsTimerWorking) // already counting time
        {
            //we have to prevent from starting again
            throw new InvalidOperationException("Nope, you can't do that");
        }
        else
        {
            // kick off the timer
            StopWatch = Stopwatch.StartNew();

            IsTimerWorking = true;
        }
    }

    public void Stop()
    {
        // actuall stop the watch
        StopWatch.Stop();

        // toggle the flag back to false
        IsTimerWorking = false;
    }
}

public class Clock
{
    public void DoNothing()
    {

    }
}