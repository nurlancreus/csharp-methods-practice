using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_tasks_part1.Entities
{
    internal class Asus : Computer
    {
        public Asus(string model, int ram, string cpu)
        {
            this.Brand = "Asus";
            this.Model = model;
            this.Ram = ram;
            this.Cpu = cpu;
        }
    }
}
