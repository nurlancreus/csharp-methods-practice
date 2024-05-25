using College.Core.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Core.Models
{
    public enum Grade
    {
        A_Plus = 90,
        A = 85,
        A_Minus = 80,
        B_Plus = 75,
        B = 70,
        B_Minus = 65,
        C_Plus = 60,
        C = 55,
        C_Minus = 50,
        D_Plus = 45,
        D = 40,
        D_Minus = 35,
        F = 0
    }
    public class StudentGrade() : BaseEntity(Table.StudentGrade)
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Grade Grade { get; set; }
    }
}
