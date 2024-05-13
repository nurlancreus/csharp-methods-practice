using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Models.BaseModel
{
    public class BaseEntity
    {
        private static int _count = 0;
        public readonly int Id;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseEntity()
        {
            Id = ++_count;
        }
    }
}
