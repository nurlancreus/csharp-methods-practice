using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Models.BaseModels
{
    public enum Table
    {
        Student,
        Teacher,
        Group,
        TeacherGroup,
        Subject,
        StudentGrade
    }

    public class BaseEntity
    {
        static private int _studentCount = 0;
        static private int _teacherCount = 0;
        static private int _groupCount = 0;
        static private int _subjectCount = 0;
        static private int _studentGradeCount = 0;
        static private int _teacherGroupCount = 0;

        public int Id { get; private set; }
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;
        public DateTime UpdatedAt { get; set; } = DateTime.MinValue;

        public BaseEntity(Table table)
        {
            if (table == Table.Student) Id = ++_studentCount;
            else if (table == Table.Teacher) Id = ++_teacherCount;
            else if (table == Table.Group) Id = ++_groupCount;
            else if (table == Table.Subject) Id = ++_subjectCount;
            else if (table == Table.StudentGrade) Id = ++_studentGradeCount;
            else if (table == Table.TeacherGroup) Id = ++_teacherGroupCount;
        }

    }
}
