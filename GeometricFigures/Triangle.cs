using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Triangle : Figure
    {
        int a;
        int b;
        int c;

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override string Name => "Треугольник";

        public override double Square()
        {
            var p = (a+b+c)/2d;
            var s = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
            return s;
        }

        public override double Perimeter()
        {
            return a+b+c;
        }
    }
}
