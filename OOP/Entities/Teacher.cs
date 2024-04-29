using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Entities
{
    internal class Teacher : PersonTest
    {
        private decimal _salary; // Use a numeric type to store salary

        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary cannot be negative.");
                    // Alternatively, you can handle this error in another way (e.g., setting a minimum value)
                }
                _salary = value;
            }
        }

        // constructor overloads below
        public Teacher(string name)
        {
            this.Name = name;
        }

        public Teacher(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public Teacher()
        {
            
        }

    }
}
