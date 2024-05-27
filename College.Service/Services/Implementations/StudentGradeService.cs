using College.Core.Models;
using College.Data.Repositories.Implementations;
using College.Data.Repositories.Interfaces;
using College.Service.Exceptions;
using College.Service.Helpers;
using College.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace College.Service.Services.Implementations
{
    public class StudentGradeService : IStudentGradeService
    {
        private readonly IStudentGradeRepository _studentGradeRepository = new StudentGradeRepository();
        private readonly IStudentRepository _studentRepository = new StudentRepository();
        private readonly ISubjectRepository _subjectRepository = new SubjectRepository();

        public async Task AddAsync()
        {
            Console.WriteLine("Add Student Grade\n");
            try
            {
                (int studentId, int subjectId, Grade grade) = await GetStudentGradeDataAsync();

                StudentGrade studentGrade = new()
                {
                    StudentId = studentId,
                    SubjectId = subjectId,
                    Grade = (Grade)grade,
                    CreatedAt = DateTime.Now
                };

                await _studentGradeRepository.AddAsync(studentGrade);
                Logger.SuccessConsole("Grade Added Successfully.");
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Delete Student Grade\n");

            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the grade you want to delete: ");

                bool gradeDeleted = await _studentGradeRepository.DeleteAsync(id);

                if (!gradeDeleted) throw new Exception("Could not delete the grade.");
                Logger.SuccessConsole("Grade Deleted Successfully.");

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            List<StudentGrade> grades = await _studentGradeRepository.GetAllAsync();
            try
            {
                if (grades.Count == 0) throw new Exception("There are no grade in the repo.");

                foreach (StudentGrade studentGrade in await _studentGradeRepository.GetAllAsync())
                {
                    await GetGradeDetailsAsync(studentGrade);
                }

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetAsync()
        {
            Console.WriteLine("Get Student Grade\n");

            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the grade you want to get: ");
                StudentGrade studentGrade = await _studentGradeRepository.GetByIdAsync(id) ?? throw new EntryPointNotFoundException("Grade Not Found");

                await GetGradeDetailsAsync(studentGrade);
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task UpdateAsync()
        {
            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the grade you want to update: ");
                StudentGrade studentGrade = await _studentGradeRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Grade Not Found");
                (int studentId, int subjectId, Grade grade) = await GetStudentGradeDataAsync();

                studentGrade.SubjectId = subjectId;
                studentGrade.StudentId = studentId;
                studentGrade.Grade = grade;
                studentGrade.UpdatedAt = DateTime.Now;

                bool gradeUpdated = await _studentGradeRepository.UpdateAsync(studentGrade);

                if (!gradeUpdated) throw new Exception("Could not update the grade");
                Logger.SuccessConsole("Grade Updated Successfully.");
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

        }

        private async Task GetGradeDetailsAsync(StudentGrade studentGrade)
        {
            Student student = await _studentRepository.GetByIdAsync(studentGrade.StudentId) ?? throw new EntityNotFoundException("Student Not Found");
            Subject subject = await _subjectRepository.GetByIdAsync(studentGrade.SubjectId) ?? throw new EntityNotFoundException("Subject Not Found");

            Console.WriteLine($"Id: {studentGrade.Id} - " +
                $"Student Fin code: {student.FinCode} - " +
                $"Student: {student.FirstName + " " + student.LastName} - " +
                $"Subject: {subject.Name} - " +
                $"Grade: {Utilities.FormatGrade(studentGrade.Grade)}");
        }

        private async Task<(int studentId, int subjectId, Grade grade)> GetStudentGradeDataAsync()
        {
            int studentId = (int)Utilities.ReadNumber("Enter id of the student who grade belongs to: ");
            Student student = await _studentRepository.GetByIdAsync(studentId) ?? throw new EntityNotFoundException("Student Not Found");

            int subjectId = (int)Utilities.ReadNumber("Enter id of the subject which grade belongs to: ");
            Subject subject = await _subjectRepository.GetByIdAsync(subjectId) ?? throw new EntityNotFoundException("Subject Not Found");

            bool isStudentAlreadyGotGrade = (await _studentGradeRepository.GetAllAsync()).Any(g => g.SubjectId == subjectId && g.StudentId == studentId);
            if (isStudentAlreadyGotGrade) throw new Exception($"Student ({student.FinCode}) already got his/her grade from subject \"{subject.Name}\"");

            Grade grade;

            while (true)
            {
                Console.WriteLine("Student Grades for scores: ");
                foreach (Grade g in Enum.GetValues<Grade>())
                {
                    Console.WriteLine($"{(int)g}+ score: {Utilities.FormatGrade(g)}");
                }
                double studentScore = Utilities.ReadNumber("Enter student score: ");

                try
                {
                    if (studentScore >= 90) grade = Grade.A_Plus;
                    else if (studentScore >= 85) grade = Grade.A;
                    else if (studentScore >= 80) grade = Grade.A_Minus;
                    else if (studentScore >= 75) grade = Grade.B_Plus;
                    else if (studentScore >= 70) grade = Grade.B;
                    else if (studentScore >= 65) grade = Grade.B_Minus;
                    else if (studentScore >= 60) grade = Grade.C_Plus;
                    else if (studentScore >= 55) grade = Grade.C;
                    else if (studentScore >= 50) grade = Grade.C_Minus;
                    else if (studentScore >= 45) grade = Grade.D_Plus;
                    else if (studentScore >= 40) grade = Grade.D;
                    else if (studentScore >= 35) grade = Grade.D_Minus;
                    else if (studentScore >= 0 && studentScore <= 100) grade = Grade.F;
                    else throw new ArgumentOutOfRangeException("Student score must be between 0 and 100.");

                    break;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Logger.ExceptionConsole(ex.Message);
                }

            }

            return (studentId, subjectId, grade);
        }


    }
}
