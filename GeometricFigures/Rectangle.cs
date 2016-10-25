using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Rectangle : Figure
    {
        int a;
        int b;

        public Rectangle(int sideA, int sideB)
        {
            a = sideA;
            b = sideB;
        }

        public override string Name => "Прямоугольник";

        public override double Square()
        {
            return a * b;
        }

        public override double Perimeter()
        {
            return (a + b) * 2;
        }
    }
}
