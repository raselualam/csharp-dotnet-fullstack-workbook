using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Instance of Stack Class
        Stack myStack = new Stack();

        try
        {
            myStack.Push("erik");
            myStack.Push(1234567);
            myStack.Push(DateTime.Now);
            myStack.Push(true);
            myStack.Push(null); // exception 
        }
        catch(InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        

        Console.WriteLine(myStack.Pop()); // true
        Console.WriteLine(myStack.Pop()); // datetime
        Console.WriteLine(myStack.Pop()); // 1234567
        Console.WriteLine(myStack.Pop()); // "erik"

        Console.ReadLine();
    }
}


public class Stack
{
    //Properties
    List<object> lifo { get; set; }

    // Constructor
    public Stack()
    {
        lifo = new List<object>();
    }

    //Methods

    // push
    public void Push(object obj)
    {
        if (obj == null)
        {
            throw new InvalidOperationException("You can't save a null object");
        }

        lifo.Add(obj);
    }

    // pop
    public object Pop()
    {
        if ( lifo.Count == 0) 
        {
            throw new InvalidOperationException("There is no more objects in the LIFO list");
        }

        int indexOfLast = lifo.Count - 1; //zero based index

        object cloned = lifo[indexOfLast];

        lifo.RemoveAt(indexOfLast);

        return cloned;
    }

    // clear --remove all elements from the lifo list
    public void Clear()
    {
        lifo.Clear();
    }
}