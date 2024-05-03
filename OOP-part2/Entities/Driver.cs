using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_part2.Entities
{
    internal class Driver : Employee
    {
        public Driver() : base(14.06F, 330)
        {

        }

        public Driver(float salaryPerHour, int workHours) : base(salaryPerHour, workHours)
        {

        }
    }
}
