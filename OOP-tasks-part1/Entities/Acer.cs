using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_tasks_part1.Entities
{
    internal class Acer : Computer
    {
        public Acer(string model, int ram, string cpu) : base("Acer", model, ram, cpu)
        {

        }
    }
}
