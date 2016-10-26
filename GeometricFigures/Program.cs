using System;
using System.Collections.Generic;
using System.Linq;

namespace GeometricFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            var figures = new List<Figure>();
            figures.Add(new Rectangle(1, 2));
            figures.Add(new Circle(1));
            figures.Add(new Triangle(1, 2, 3));

            var sPerimeter = CalcFullPerimetr(figures.Where(x => x.Name == "Треугольник" && x.Color == ""));
            Console.WriteLine("SPerimeter:" + sPerimeter);

            var rnd = new Random((int)DateTime.UtcNow.Ticks);

            var arrFigures = new Figure[3, 5];
            for (int i = 0; i < arrFigures.GetLength(0); i++)
            {
                for (int j = 0; j < arrFigures.GetLength(1); j++)
                {
                    if (i == 0)
                        arrFigures[i, j] = new Rectangle(rnd.Next(5, 10), rnd.Next(5, 10));
                    else if (i == 1)
                        arrFigures[i, j] = new Triangle(rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5));
                    else
                        arrFigures[i, j] = new Circle(rnd.Next(10, 20));
                    Console.WriteLine($"Периметр {arrFigures[i,j].Name} = {arrFigures[i,j].Perimeter()}");
                }
            }

            var sSquare = CalcFullSquare(arrFigures);
            Console.WriteLine($"Сумма площадей {sSquare}");

            Console.ReadKey();
        }

        private static double CalcFullSquare(Figure[,] arrFigures)
        {
            var sSquare = 0;
            for (int i = 0; i < arrFigures.GetLength(0); i++)
            {
                for (int j = 0; j < arrFigures.GetLength(1); j++)
                {
                    sSquare += (int) arrFigures[i, j].Square();
                }
            }
            return sSquare;
        }


        private static double CalcFullPerimetr(IEnumerable<Figure> figures)
        {
            var sPerimeter = figures.Sum(x => x.Perimeter());
            return sPerimeter;
        }
    }
}

