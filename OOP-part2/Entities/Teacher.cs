using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_part2.Entities
{
    internal class Teacher : Employee
    {
        public Teacher() : base(30.0F, 212)
        {

        }

        public Teacher(float salaryPerHour, int workHours) : base(salaryPerHour, workHours)
        {

        }
    }
}
