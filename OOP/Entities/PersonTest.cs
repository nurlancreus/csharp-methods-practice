using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Entities
{
    internal abstract class PersonTest
    {
        private int _age;

        // Properties
        public string Name { get; set; }
        public string Surname { get; set; }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    _age = 0;
                }
                else _age = value;

            }
        }
    }
}
