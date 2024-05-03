using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_part2.Entities
{
    internal abstract class Figure
    {
        private int _side;
        private int _sideCount;

        protected Figure(int sideCount, int side)
        {
            SideCount = sideCount;
            Side = side;
        }
        public int Side
        {
            get => _side;
            set
            {
                if (value < 0) throw new ArgumentException("Side cannot be negative");
                _side = value;
            }
        }

        public int SideCount
        {
            get => _sideCount;
            set
            {
                if (value < 3) throw new ArgumentException("Side count should at least be 3");
                _sideCount = value;
            }
        }

        public int CalculatePerimeter() { return Side * SideCount; }
    }
}
