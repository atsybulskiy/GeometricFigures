using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rectangle, Int: A, B: ");
            var a = Int32.Parse(Console.ReadLine());
            var b = Int32.Parse(Console.ReadLine());

            Rectangle rect1 = new Rectangle(a, b);
            Figure fig1 = rect1;
            //Figure fig2 = new Figure(); 

            Console.WriteLine("Triangle, Int: A, B, C: ");
            a = Int32.Parse(Console.ReadLine());
            b = Int32.Parse(Console.ReadLine());
            var c= Int32.Parse(Console.ReadLine());

            Triangle triag1 = new Triangle(a,b,c);
            Figure fig3 = triag1;

            Console.WriteLine("Circle, Int: R: ");
            var r = Int32.Parse(Console.ReadLine());
            Circle circ = new Circle(r);
            Figure fig4 = circ;
            
            // Rectangle
            Console.WriteLine($"Rectangle Square = {fig1.Square()}");
            Console.WriteLine($"Rectangle Perimeter = {fig1.Perimeter()}");
            
            // Triangle
            Console.WriteLine($"Triange Square = {fig3.Square()}");
            Console.WriteLine($"Triange Perimeter = {fig3.Perimeter()}");

            // Circle
            Console.WriteLine($"Circle Square = {fig4.Square()}");
            Console.WriteLine($"Circle Perimeter = {fig4.Perimeter()}");

            Console.WriteLine($"Total Perimeter = {fig1.Perimeter() + fig3.Perimeter() + fig4.Perimeter()}");
            Console.WriteLine($"Total Square = {fig1.Square() + fig3.Square() + fig4.Square()}");

            Console.ReadKey();
        }
    }
}

