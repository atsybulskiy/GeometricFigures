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
            IEnumerable<Figure> enum1;

            enum1 = new Rectangle[0].Cast<Figure>();


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
                    {
                        arrFigures[i, j] = new Rectangle(rnd.Next(5, 10), rnd.Next(5, 10));
                    }
                    else if (i == 1)
                    {
                        arrFigures[i, j] = new Triangle(rnd.Next(2, 5), rnd.Next(2, 5), rnd.Next(2, 5));
                    }
                    else
                    {
                        arrFigures[i, j] = new Circle(rnd.Next(10, 20));
                    }
                    Console.WriteLine($"Периметр {arrFigures[i, j].Name} = {arrFigures[i, j].Square()}");
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
                //sSquare++;
            }

            return sSquare;
        }


        private static double CalcFullPerimetr(IEnumerable<Figure> figures)
        {
            var sPerimeter = figures.Sum(x => x.Perimeter());
            return sPerimeter;
        }
    }

    class MyEnumerator<T> : IEnumerator<T>
    {
        private readonly T[,] _source;
        private int _positionX;
        private int _positionY;


        public MyEnumerator(T[,] source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            _source = source;
        }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (_positionX >= _source.GetLength(0)) return false;
            //if (_positionY >= _source.GetLength(1)) return true;
            if (_positionY == _source.GetLength(1) - 1)
            {
                _positionX++;
                _positionY = 0;
                return _positionX != _source.GetLength(0);
            }
            _positionY++;
            return true;
        }

        public void Reset()
        {
            _positionX = 0;
            _positionY = 0;
        }

        public T Current => _source[_positionX, _positionY];

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }

    class MyEnumeratorProxy<T> : IEnumerable<T>
    {
        private readonly T[,] _source;

        public MyEnumeratorProxy(T[,] source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            _source = source;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_source);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

