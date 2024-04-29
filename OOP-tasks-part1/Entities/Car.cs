using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_tasks_part1.Entities
{
    internal class Car
    {
        private string _brand;
        private string _model;
        private int _year;

        public Car(string brand, string model, int year)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
        }

        public string Brand
        {
            get { return _brand; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Give proper brand");
                _brand = value;
            }
        }
        
        public string Model
        {
            get { return _model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Give proper model");
                _model = value;
            }
        }
        
        public int Year
        {
            get { return _year; }
            set
            {
                if (value < 1886)
                {
                    throw new ArgumentException("The first modern car appeared in 1886, it cannot be before that");
                }
                _year = value;
            }
        }
    }
}
