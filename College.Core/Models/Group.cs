using College.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Models
{
    public class Group() : BaseEntity(Table.Group)
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<TeacherGroup> teacherGroups = [];

        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name} - Description: {Description}";
        }
    }
}
