using College.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Models
{
    public class TeacherGroup() : BaseEntity(Table.TeacherGroup)
    {
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
    }
}
