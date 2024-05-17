using E_Commerce.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Models
{
    public class Shop : BaseEntity
    {
        private float _rating = 0;
        public Shop() : base("shop")
        {

        }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public float Rating
        {
            get => _rating;

            set
            {
                if (value >= 0 && value <= 5.0)
                {
                    _rating = value;
                }
                else throw new ArgumentOutOfRangeException("Rating value must be between 0 - 5.0 range");
            }
        }

        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name} - Description: {Description} - Rating: {Rating} - Created: {CreatedAt}";
        }
    }
}
