using System;
using System.Collections;
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

            //var sPerimeter = CalcFullPerimetr(figures.Where(x => x.Name == "Треугольник" && x.Color == ""));
            //Console.WriteLine("SPerimeter:" + sPerimeter);

            var rnd = new Random((int) DateTime.UtcNow.Ticks);

            var arrFigures = new Figure[3, 5];

            for (var i = 0; i < arrFigures.GetLength(0); i++)
            {
                for (var j = 0; j < arrFigures.GetLength(1); j++)
                {
                    switch (i)
                    {
                        case 0:
                            arrFigures[i, j] = new Rectangle(rnd.Next(5, 10), rnd.Next(5, 10));
                            break;
                        case 1:
                            arrFigures[i, j] = new Triangle(rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5));
                            break;
                        default:
                            arrFigures[i, j] = new Circle(rnd.Next(10, 20));
                            break;
                    }
                    //Console.WriteLine($"Периметр {arrFigures[i, j].Name} = {arrFigures[i, j].Square()}");
                }
            }

            var sSquare = CalcFullSquare(arrFigures);
            Console.WriteLine($"Сумма площадей   {sSquare}");
            var sSquare2 = CalcFullSquare2(arrFigures);
            Console.WriteLine($"Сумма площадей 2 {sSquare2}");
            var sSquare3 = CalcFullSquare3(arrFigures);
            Console.WriteLine($"Сумма площадей 3 {sSquare3}");

            Console.ReadKey();
        }

        private static double CalcFullSquare(Figure[,] arrFigures)
        {
            double sSquare = 0;
            for (var i = 0; i < arrFigures.GetLength(0); i++)
                for (var j = 0; j < arrFigures.GetLength(1); j++)
                {
                    sSquare += arrFigures[i, j].Square();
                }

            return sSquare;
        }

        private static double CalcFullSquare2(Figure[,] arrFigures)
        {
            double sSquare = 0;
            foreach (var x in arrFigures)
            {
                sSquare += x.Square();
                //sSquare++;
            }

            return sSquare;
        }

        private static double CalcFullSquare3(Figure[,] arrFigures)
        {
            double sSquare = 0;
            foreach (var x in new MyEnumeratorProxy<Figure>(arrFigures))
            {
                sSquare += x.Square();
                Console.WriteLine(x);
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