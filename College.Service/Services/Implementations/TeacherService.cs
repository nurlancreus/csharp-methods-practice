using College.Core.Models;
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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository = new TeacherRepository();
        private readonly ITeacherGroupRepository _teacherGroupRepository = new TeacherGroupRepository();
        private readonly IGroupRepository _groupRepository = new GroupRepository();
        private readonly ISubjectRepository _subjectRepository = new SubjectRepository();

        public async Task AddAsync()
        {
            Console.WriteLine("Add Teacher\n");

            try
            {
                (string firstName, string lastName, string fatherName, string finCode) = await GetTeacherDataAsync();

                Teacher teacher = new()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    FatherName = fatherName,
                    FinCode = finCode,
                    CreatedAt = DateTime.Now
                };

                await _teacherRepository.AddAsync(teacher);
                Logger.SuccessConsole("Teacher Added Successfully.");
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Delete teacher\n");

            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the teacher you want to delete: ");
                bool teacherDeleted = await _teacherRepository.DeleteAsync(id);

                if (!teacherDeleted) throw new EntityNotFoundException("Could not delete the teacher.");
                Logger.SuccessConsole("Teacher Deleted Successfully.");
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            Console.WriteLine("Get All Teachers\n");
            List<Teacher> teachers = await _teacherRepository.GetAllAsync();

            try
            {
                if (teachers.Count == 0) throw new Exception("There are no teacher in the repo.");
                foreach (Teacher teacher in await _teacherRepository.GetAllAsync())
                {
                    Console.WriteLine(teacher);
                }
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetAsync()
        {
            Console.WriteLine("Get Teacher\n");

            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the teacher you want to get: ");
                Teacher teacher = await _teacherRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Teacher Not Found.");

                Console.WriteLine(teacher);
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetTeacherGroupsAsync(string assignmentType)
        {
            List<TeacherGroup> teacherGroups = await _teacherGroupRepository.GetAllAsync();

            try
            {
                if (teacherGroups.Count == 0) throw new Exception($"There are no Teacher group data now");

                int id = (int)Utilities.ReadNumber($"Enter the Id of the teacher you want to get {assignmentType} of: ");
                Teacher teacher = await _teacherRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Teacher Not Found.");

                List<TeacherGroup> teacherAssignments = teacherGroups.FindAll(tg => tg.TeacherId == id);

                if (teacherAssignments.Count == 0) throw new Exception($"Teacher ({teacher.FinCode}) got no groups now.");

                Console.WriteLine($"{assignmentType[..1].ToUpper() + assignmentType[1..]}: ");

                for (int i = 0; i < teacherAssignments.Count; i++)
                {
                    TeacherGroup teacherGroup = teacherAssignments[i];
                    if (assignmentType == "groups")
                    {
                        Group group = await _groupRepository.GetByIdAsync(teacherGroup.GroupId) ?? throw new EntityNotFoundException("Group Not Found.");
                        Console.WriteLine($"{i+1}. {group.Name}");

                    }
                    else
                    {
                        Subject subject = await _subjectRepository.GetByIdAsync(teacherGroup.SubjectId) ?? throw new EntityNotFoundException("Subject Not Found.");
                        Console.WriteLine($"{i+1}. {subject.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task UpdateAsync()
        {
            Console.WriteLine("Update Teacher\n");

            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the teacher you want to update: ");
                Teacher teacher = await _teacherRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Teacher Not Found.");

                (string firstName, string lastName, string fatherName, string finCode) = await GetTeacherDataAsync();

                teacher.FirstName = firstName;
                teacher.LastName = lastName;
                teacher.FatherName = fatherName;
                teacher.FinCode = finCode;
                teacher.UpdatedAt = DateTime.Now;

                bool teacherUpdated = await _teacherRepository.UpdateAsync(teacher);

                if (!teacherUpdated) throw new Exception("Could not update the teacher.");
                Logger.SuccessConsole("Teacher Updated Successfully.");

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        private async Task<(string firstName, string lastName, string fatherName, string finCode)> GetTeacherDataAsync()
        {
            string firstName = Utilities.ReadString("Enter teacher's first name: ");
            string lastName = Utilities.ReadString("Enter teacher's last name: ");
            string fatherName = Utilities.ReadString("Enter teacher's father's name: ");
            string finCode = Utilities.ReadString("Enter teacher's fin code: ");

            if (finCode.Length != 7) throw new Exception("Fin Code's length should be 7");

            return await Task.FromResult((firstName, lastName, fatherName, finCode));
        }
    }
}
