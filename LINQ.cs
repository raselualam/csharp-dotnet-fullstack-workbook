using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>()
        {
            new Person () { FirstName = "Erik", LastName="Zambrano", Birthdate = DateTime.Now.AddYears(-32)},
            new Person () { FirstName = "John", LastName="Smith", Birthdate = Convert.ToDateTime("09/12/1999")},
            new Person () { FirstName = "Susan", LastName="Pine", Birthdate = Convert.ToDateTime("01/10/2000")},
            new Person () { FirstName = "Juan", LastName="Gonzales", Birthdate = Convert.ToDateTime("07/27/1980")}
        };

        //List<Person> peopleWithJ = new List<Person>();

        //foreach (var p in people)
        //{
        //    if (p.FirstName[0] == 'J')
        //    {
        //        peopleWithJ.Add(p);
        //    }
        //}

        // Linq Queries
        var peopleYounger30 = from p in people
                              where DateTime.Today.Year - p.Birthdate.Year < 30
                              orderby p.LastName descending
                              select $"{p.FirstName} {p.LastName}";

        // Linq Methods
        var peopleOlder30 = people
            .Where(p => DateTime.Today.Year - p.Birthdate.Year > 30)
            .OrderByDescending(p => p.LastName)
            .Select(p => $"{p.FirstName} {p.LastName}");

        foreach (var p in peopleYounger30)
        {
            Console.WriteLine(p);
        }

        foreach (var p in peopleOlder30)
        {
            Console.WriteLine(p);
        }

        Console.ReadLine();
    }
}


public class Person
{
    // Properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }

}