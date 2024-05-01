using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace OOP_tasks_part1.Entities
{
    abstract internal class Computer
    {
        private string? _brand;
        private string? _model;
        private string? _ram;
        private string? _cpu;

        protected Computer(string brand, string model, int ram, string cpu)
        {
            Brand = brand;
            Model = model;
            RamNum = ram;
            Cpu = cpu;
        }

        public string Brand
        {
            get => _brand;
            protected set
            {

                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Give proper Brand");

                _brand = value;
            }
        }
        public string Model
        {
            get => _model;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Give proper Model");

                _model = value;
            }
        }
        public int RamNum
        {
            get
            {
                // Remove any non-numeric characters from the string
                string? numericPart = new String(Ram?.Where(char.IsDigit).ToArray());

                // Convert the extracted numeric part to an integer
                if (int.TryParse(numericPart, out int ramSize))
                {
                    return ramSize;
                }
                else
                {
                    throw new ArgumentException("Failed to extract RAM size.");
                }

            }
            protected set
            {
                if (value < 0) throw new ArgumentException("Ram cannot be negative");
                _ram = $"{value} GB";
            }
        }

        public string Ram => _ram;

        public string Cpu
        {
            get => _cpu;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Give proper Cpu");
                _cpu = value;
            }
        }
    }
}
