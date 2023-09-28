using System;

namespace FigureSquary
{
    public class Circle: Figure
    {
        public double Radius { get; }

        /// <exception cref="ArgumentOutOfRangeException">if parameter is equal to or less than 0</exception>
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException("Parameter is equal to or less than 0");

            this.Radius = radius;
        }

        /// <summary>
        /// returns square circle
        /// </summary>
        public override double Square()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
