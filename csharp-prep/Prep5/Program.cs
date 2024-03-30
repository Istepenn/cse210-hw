using System;
using System.Collections.Generic;

public abstract class Shape
{
    public string Color { get; }

    public Shape(string color)
    {
        Color = color;
    }

    public abstract float GetArea();
}

public class Square : Shape
{
    private readonly float _side;

    public Square(string color, float side) : base(color)
    {
        _side = side;
    }

    public override float GetArea()
    {
        return _side * _side;
    }
}

public class Rectangle : Shape
{
    private readonly float _length;
    private readonly float _width;

    public Rectangle(string color, float length, float width) : base(color)
    {
        _length = length;
        _width = width;
    }

    public override float GetArea()
    {
        return _length * _width;
    }
}

public class Circle : Shape
{
    private readonly float _radius;

    public Circle(string color, float radius) : base(color)
    {
        _radius = radius;
    }

    public override float GetArea()
    {
        return (float)Math.PI * _radius * _radius;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.Color}, Area: {shape.GetArea()}");
        }
    }
}
