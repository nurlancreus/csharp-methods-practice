using College.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Models
{
    public class Student() : Person(Table.Student)
    {
        public int GroupId { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} - GroupId: {GroupId}";
        }
    }
}
