using E_Commerce.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Models
{
    public class Customer : BaseEntity
    {
        public Customer() : base("customer")
        {
        }

        public string Name { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty; 

        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name} - Surname: {Surname} - Address: {Address} - Phone: {Phone} - Created: {CreatedAt}";
        }
    }
}
