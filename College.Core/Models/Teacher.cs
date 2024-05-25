using College.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Models
{
    public class Teacher() : Person(Table.Teacher)
    {
        public List<TeacherGroup> teacherGroups = [];
    }
}
