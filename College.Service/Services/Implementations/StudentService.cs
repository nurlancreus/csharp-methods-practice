﻿using College.Core.Models;
using College.Data.Repositories.Implementations;
using College.Data.Repositories.Interfaces;
using College.Service.Exceptions;
using College.Service.Helpers;
using College.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository = new StudentRepository();
        private readonly IGroupRepository _groupRepository = new GroupRepository();
        public async Task AddAsync()
        {
            Console.WriteLine("Add Student\n");
            try
            {
                (string firstName, string lastName, string fatherName, string finCode, int groupId) = await GetStudentDataAsync();

                Group group = await _groupRepository.GetByIdAsync(groupId) ?? throw new EntityNotFoundException("Group not found");
                Student student = new()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    FatherName = fatherName,
                    FinCode = finCode,
                    GroupId = groupId,
                    CreatedAt = DateTime.Now,
                };

                await _studentRepository.AddAsync(student);
                Logger.SuccessConsole("Student Added Successfully.");

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Delete Student\n");
            try
            {
                int id = (int)Utilities.ReadNumber("Enter the id of the student you want to delete: ");
                bool studentDeleted = await _studentRepository.DeleteAsync(id);

                if (!studentDeleted) throw new EntityNotFoundException("Could not delete the student.");
                Logger.SuccessConsole("Student Deleted Successfully.");

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            Console.WriteLine("Get All Students\n");
            List<Student> students = await _studentRepository.GetAllAsync();

            try
            {
                if (students.Count == 0) throw new Exception("There are no student in the repo.");
                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetAsync()
        {
            Console.WriteLine("Get Student\n");

            try
            {
                int id = (int)Utilities.ReadNumber("Enter the id of the student you want to get: ");
                Student student = await _studentRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Student not found");
                Console.WriteLine(student);

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task UpdateAsync()
        {
            Console.WriteLine("Update Student\n");

            try
            {
                int id = (int)Utilities.ReadNumber("Enter the id of the student you want to update: ");

                Student student = await _studentRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Student not found");

                (string firstName, string lastName, string fatherName, string finCode, int groupId) = await GetStudentDataAsync();

                Group group = await _groupRepository.GetByIdAsync(groupId) ?? throw new EntityNotFoundException("Group not found.");

                student.FirstName = firstName;
                student.LastName = lastName;
                student.FatherName = fatherName;
                student.FinCode = finCode;
                student.GroupId = groupId;
                student.UpdatedAt = DateTime.Now;

                bool studentUpdated = await _studentRepository.UpdateAsync(student);

                if (!studentUpdated) throw new Exception("Could not update the student.");
                Logger.SuccessConsole("Student Updated Successfully.");

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        private async Task<(string firstName, string lastName, string fatherName, string finCode, int groupId)> GetStudentDataAsync()
        {
            string firstName = Utilities.ReadString("Enter student's first name: ");
            string lastName = Utilities.ReadString("Enter student's last name: ");
            string fatherName = Utilities.ReadString("Enter student's father's name: ");
            string finCode = Utilities.ReadString("Enter student's fin code: ");

            if (finCode.Length != 7) throw new ArgumentOutOfRangeException("Fin Code's length should be 7");

            int groupId = (int)Utilities.ReadNumber("Enter the id of the group where student studies: ");

            return await Task.FromResult((firstName, lastName, fatherName, finCode, groupId));
        }
    }
}
