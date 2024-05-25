using College.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Models
{
    public class Subject() : BaseEntity(Table.Subject)
    {
        public string Name { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name}";
        }
    }
}
