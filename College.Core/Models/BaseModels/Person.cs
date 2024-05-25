using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Models.BaseModels
{
    public class Person(Table profession) : BaseEntity(profession)
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string FinCode { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Id: {Id} - First Name: {FirstName} - Last Name: {LastName} - Father Name: {FatherName} - Fin Code: {FinCode} - Created: {CreatedAt} - Updated: {(UpdatedAt == DateTime.MinValue ? "_" : UpdatedAt)}";
        }
    }
}
