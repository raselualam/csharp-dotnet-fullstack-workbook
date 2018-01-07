using System;

public class Program
{
    public static void Main()
    {
        Shape r = new Rectangle(34, 12); // Upcasting 

        Shape t = new Triangle(12, 45, 67);
        
        ShowPerimter(t);
        ShowPerimter(r);

        Console.ReadLine();
    }

    public static void ShowPerimter(Shape s)
    {
        Console.WriteLine(s.Perimeter());
    }
}

public abstract class Shape
{
    // Properties
    public int Height { get; set; }
    public int Width { get; set; }

    // Constructor
    public Shape(int h, int w)
    {
        Height = h;
        Width = w;
    }

    // Method

    public abstract int Area();

    public abstract int Perimeter();
}

public class Rectangle : Shape
{
    // properties that are inherited
    // Height
    // Width 

    public Rectangle(int h, int w) : base(h, w)
    {
        // Will run after the Shape() constructor
    }

    public int Angles() => 4; // lambda expression

    public override int Area() => Height * Width;

    public override int Perimeter() => (Height + Width) * 2;
}

public class Triangle : Shape
{
    // Height
    // Width 
    public int Diagonal { get; set; }

    public Triangle(int h, int w, int d) : base(h, w)
    {
        // Height = h;
        // Width = w;
        Diagonal = d;
    }

    public int Angles() => 3;

    public override int Area()
    {
        // Heron's formula

        var s = Perimeter() / 2;

        var result = Math.Sqrt(s * (s - Height) * (s - Diagonal) * (s - Width));

        return Convert.ToInt32(Math.Floor(result));
    }

    public override int Perimeter() => Height + Diagonal + Width;
}