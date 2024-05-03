using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_part2.Entities
{
    internal abstract class Employee
    {
        private float _salaryPerHour;
        private int _workHours;

        protected Employee(float salaryPerHour, int workHours)
        {
            SalaryPerHour = salaryPerHour;
            WorkHours = workHours;
        }

        public float SalaryPerHour
        {
            get { return _salaryPerHour; }
            set
            {

                if (value < 0) throw new ArgumentException("Salary per hour cannot be negative");
                _salaryPerHour = value;
            }
        }
        public int WorkHours
        {
            get { return _workHours; }
            set
            {
                if (value < 0) throw new ArgumentException("Work hours cannot be negative");
                _workHours = value;
            }
        }

        public float CalculateSalaryPerMonth()
        {
            return (float)Math.Round(SalaryPerHour * WorkHours, 2);
        }
    }
}
