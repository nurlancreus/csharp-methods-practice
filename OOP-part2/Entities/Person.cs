using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_part2.Entities
{
    internal class Person
    {
        private string? _id = null;
        private string _name = "";
        private int _age = 0;

        public Person(string name, int age)
        {
            _id = GenerateId();
            SetName(name);
            SetAge(age);
        }

        public Person()
        {
            _id = GenerateId();
        }

        public string GetId() => _id;
        public string GetName() => _name;
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("please, enter valid name");
            _name = name;
        }

        public int GetAge() => _age;
        public void SetAge(int age)
        {
            if (age < 0 || age > 150) throw new ArgumentNullException("please, enter valid age");
            _age = age;
        }

        private string GenerateId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
