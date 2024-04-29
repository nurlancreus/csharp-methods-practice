using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_tasks_part1.Entities
{
    internal class Lenovo : Computer
    {
        public Lenovo(string model, int ram, string cpu)
        {
            this.Brand = "Lenovo";
            this.Model = model;
            this.Ram = ram;
            this.Cpu = cpu;
        }
    }
}
