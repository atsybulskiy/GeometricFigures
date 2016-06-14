using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Figure
    {
        public string Color;

        public Figure()
        {
            Color = "";
        }
        public virtual double Square()
        {
            double result = 1;
            return result;
        }

        public virtual double Perimeter()
        {
            double p = 1;
            return p;
        }
    }
}