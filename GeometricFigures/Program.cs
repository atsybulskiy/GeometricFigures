using System;
using System.Collections.Generic;
using System.Linq;

namespace GeometricFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Rectangle, Int: A, B: ");
            //var a = Int32.Parse(Console.ReadLine());
            //var b = Int32.Parse(Console.ReadLine());

            //Rectangle rect = new Rectangle(a, b);
            //Figure fig1 = rect;
            ////Figure fig2 = new Figure(); 

            //Console.WriteLine("Triangle, Int: A, B, C: ");
            //a = Int32.Parse(Console.ReadLine());
            //b = Int32.Parse(Console.ReadLine());
            //var c= Int32.Parse(Console.ReadLine());

            //Triangle triang = new Triangle(a,b,c);
            //Figure fig3 = triang;

            //Console.WriteLine("Circle, Int: R: ");
            //var r = Int32.Parse(Console.ReadLine());
            //Circle circ = new Circle(r);
            //Figure fig4 = circ;



            // Rectangle
            var fig1 = new Rectangle(2, 5);
            Console.WriteLine($"Rectangle Square = {fig1.Square()}");
            Console.WriteLine($"Rectangle Perimeter = {fig1.Perimeter()}");
            fig1.Color = "Желтый";

            // Triangle
            var fig3 = new Triangle(2, 2, 2);
            Console.WriteLine($"Triange Square = {fig3.Square()}" + fig3);
            Console.WriteLine($"Triange Perimeter = {fig3.Perimeter()}");

            // Circle
            var fig4 = new Circle(6);
            Console.WriteLine($"Circle Square = {fig4.Square()}");
            Console.WriteLine($"Circle Perimeter = {fig4.Perimeter()}");

            Console.WriteLine($"Total Perimeter = {fig1.Perimeter() + fig3.Perimeter() + fig4.Perimeter()}");
            Console.WriteLine($"Total Square = {fig1.Square() + fig3.Square() + fig4.Square()}");

            var figures = new List<Figure>();
            figures.Add(new Rectangle(1, 2));
            figures.Add(new Circle(1));
            figures.Add(new Triangle(1, 2, 3));

            var sPerimeter = CalcFullPerimetr(figures.Where(x => x.Name == "Треугольник" && x.Color == ""));
            Console.WriteLine("SPerimeter:" + sPerimeter);

            var rnd = new Random((int)DateTime.UtcNow.Ticks);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Random rect   = {rnd.Next(5, 10)}");
                Console.WriteLine($"Random treang = {rnd.Next(2, 5)}");
                Console.WriteLine($"Random radius = {rnd.Next(10, 20)}");
            }
            

            Console.ReadKey();
        }

        private static double CalcFullPerimetr(IEnumerable<Figure> figures)
        {
            var sPerimeter = figures.Sum(x => x.Perimeter());
            return sPerimeter;
        }
    }
}

