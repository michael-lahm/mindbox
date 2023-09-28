using System;

namespace FigureSquary
{
    public class Triangle: Figure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        /// <exception cref="ArgumentOutOfRangeException">if parameter is equal to or less than 0</exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if(sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentOutOfRangeException("Parameter is equal to or less than 0");

            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        /// <summary>
        /// returns square triangle
        /// </summary>
        public override double Square()
        {
            var semiPerimeter = (SideA + SideB + SideC) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }

        /// <summary>
        /// checking if the triangle is right angled
        /// </summary>
        /// <returns>true if triangle is right angled, false if not</returns>
        public bool RigthAngle()
        {
            double maxSide = SideA;
            if(SideB > SideA)
                maxSide = SideB;
            if(SideC > maxSide)
                maxSide = SideC;

            return (2 * maxSide * maxSide) == (SideA * SideA + SideB * SideB + SideC * SideC);
        }
    }
}
