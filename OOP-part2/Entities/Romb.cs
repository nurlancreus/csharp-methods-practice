using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_part2.Entities
{
    internal class Romb
    {
        private decimal _width = 0;
        private decimal _height = 0;

        public Romb(decimal width, decimal height)
        {
            Width = width;
            Height = height;
        }

        public decimal Width
        {
            get => _width;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Cannot give a negative input");

                _width = value;
            }
        }

        public decimal Height
        {
            get => _height;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Cannot give a negative input");

                _height = value;
            }
        }

        public decimal GetArea()
        {
            return Height * Width;
        }
    }
}
