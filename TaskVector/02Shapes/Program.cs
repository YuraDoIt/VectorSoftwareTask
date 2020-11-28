using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Shapes
{
    abstract class Shape
    {
        
        public abstract double Area();
        public abstract void ShowName();
    }

    class Square : Shape
    {
        private string name = "Square";
        private double side { get; set; }

        public override void ShowName()
        {
            Console.Write($"{name}");
        }

        public Square(double side)
        {
            this.side = side;
            
        }

        public override double Area()
        {
            return Math.Pow(side, 2);
        }

        
    }

    class Rectangle : Shape
    {
        private string name = "Rectangle";
        private double width { get; set; }
        private double height { get; set; }
        public override void ShowName()
        {
            Console.Write($"{name}");
        }
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double Area()
        {
            return width * height;
        }
    }

    class Triangle : Shape
    {
        private string name = "Trianlge";
        private double width { get; set; }
        private double height { get; set; }
        public override void ShowName()
        {
            Console.Write($"{name}");
        }
        public Triangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double Area()
        {
            return (width * height)/2;
        }
    }

    class Circle : Shape
    {
        private string name = "Circle";
        private double radius { get; set; }
        public override void ShowName()
        {
            Console.Write($"{name}");
        }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double Area()
        {
            return Math.Sqrt(radius*Math.PI);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double side = 2;
            double radius = 3;
            double based = 5;
            double height = 10;
            var shapes = new List<Shape> //add shapes to list
            {
                new Square(side),
                new Rectangle(side, height),
                new Triangle(based, height),
                new Circle(radius)
            };

            Console.WriteLine("Unsorted shapes:\n");
            foreach (var item in shapes)
            {
                item.ShowName();
                Console.Write(" - " + item.Area() + "\n");
            }

            var query = shapes.OrderBy(shp => shp.Area());

            Console.WriteLine("\nSorted shape\n");
            foreach (var item in query)
            {
                item.ShowName();
                Console.Write(" - " + item.Area() + "\n");
            }
           
        }
    }
}
