using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_tasks_part1.Entities
{
    internal class Person
    {
        private string _name;
        private string _surname;
        private int _age;

        public Person(string name, string surname, int age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Give proper Name");
                _name = value;
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Give proper Surname");
                _surname = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative.");
                }
                _age = value;
            }
        }

    }
}
