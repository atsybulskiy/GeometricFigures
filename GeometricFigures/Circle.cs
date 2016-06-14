﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Circle : Figure
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public override double Square()
        {
            return Math.PI*Math.Pow(radius, 2);
        }

        public override double Perimeter()
        {
            return 2*Math.PI*radius;
        }
    }
}