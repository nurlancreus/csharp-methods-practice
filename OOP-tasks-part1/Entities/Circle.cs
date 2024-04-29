using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_tasks_part1.Entities
{
    internal class Circle
    {
        private readonly double _PI = Math.PI;

        private double _radius;

        public Circle()
        {
            Console.WriteLine("Set Radius: ");
            this.Radius = Convert.ToDouble(Console.ReadLine());
        }

        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value < 0) throw new ArgumentException("Radius cannot be negative value");
                _radius = value;
            }
        }

        public double CalculateCircle()
        {

            return Math.Round(_radius * _radius * _PI, 2);

        }
    }
}
