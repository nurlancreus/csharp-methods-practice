using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_tasks_part1.Entities
{
    abstract internal class Computer
    {
        private string _brand;
        private string _model;
        private int _ram;
        private string _cpu;

        public string Brand
        {
            get { return _brand; }
            set
            {

                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Give proper Brand");

                _brand = value;
            }
        }
        public string Model
        {
            get { return _model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Give proper Model");

                _model = value;
            }
        }
        public int Ram
        {
            get { return _ram; }
            set
            {
                if (value < 0) throw new ArgumentException("Ram cannot be negative");
                _ram = value;
            }
        }
        public string Cpu
        {
            get { return _cpu; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Give proper Cpu");
                _cpu = value;
            }
        }
    }
}
