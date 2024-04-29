using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_tasks_part1.Entities
{
    internal class Hp : Computer
    {
        public Hp(string model, int ram, string cpu)
        {
            this.Brand = "Hp";
            this.Model = model;
            this.Ram = ram;
            this.Cpu = cpu;
        }
    }
}
