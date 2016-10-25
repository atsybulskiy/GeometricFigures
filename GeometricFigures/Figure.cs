using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public abstract class Figure
    {
        public string Color { get; set; }

        public abstract string Name { get; }

        protected Figure()
        {
            Color = "";
        }

        public abstract double Square();


        public abstract double Perimeter();

        public override string ToString()
        {
            return $"{Name}:{Color}";
        }
    }

}