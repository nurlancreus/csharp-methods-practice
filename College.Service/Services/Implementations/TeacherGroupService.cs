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
    public class TeacherGroupService : ITeacherGroupService
    {
        private readonly ITeacherGroupRepository _teacherGroupRepository = new TeacherGroupRepository();
        private readonly ITeacherRepository _teacherRepository = new TeacherRepository();
        private readonly IGroupRepository _groupRepository = new GroupRepository();
        private readonly ISubjectRepository _subjectRepository = new SubjectRepository();

        public async Task AddAsync()
        {
            Console.WriteLine("Add Teacher Group\n");

            try
            {
                (int teacherId, int groupId, int subjectId) = await GetTeacherGroupDataAsync();

                TeacherGroup teacherGroup = new()
                {
                    TeacherId = teacherId,
                    GroupId = groupId,
                    SubjectId = subjectId,
                    CreatedAt = DateTime.Now
                };

                await _teacherGroupRepository.AddAsync(teacherGroup);

                Logger.SuccessConsole("Teacher group Added Successfully.");

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Delete Teacher Group\n");
            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the teacher group you want to delete: ");

                bool teacherGroupDeleted = await _teacherGroupRepository.DeleteAsync(id);

                if (!teacherGroupDeleted) throw new Exception("Could not delete the teacher group.");
                Logger.SuccessConsole("Teacher group Deleted Successfully.");
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            Console.WriteLine("Get All Teacher Groups\n");
            List<TeacherGroup> teacherGroups = await _teacherGroupRepository.GetAllAsync();

            try
            {
                if (teacherGroups.Count == 0) throw new Exception("There are no teacher groups in the repo.");
                foreach (TeacherGroup teacherGroup in teacherGroups)
                {
                    await GetTeacherGroupDetailsAsync(teacherGroup);
                }
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetAsync()
        {
            Console.WriteLine("Get Teacher Group\n");
            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the teacher group you want to get: ");

                TeacherGroup teacherGroup = await _teacherGroupRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Teacher group Not Found.");
                await GetTeacherGroupDetailsAsync(teacherGroup);

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task UpdateAsync()
        {
            Console.WriteLine("Update Teacher Group\n");

            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the teacher group you want to update: ");
                TeacherGroup teacherGroup = await _teacherGroupRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Teacher group Not Found.");

                (int teacherId, int groupId, int subjectId) = await GetTeacherGroupDataAsync();

                teacherGroup.TeacherId = teacherId;
                teacherGroup.GroupId = groupId;
                teacherGroup.SubjectId = subjectId;
                teacherGroup.UpdatedAt = DateTime.Now;

                bool teacherGroupUpdated = await _teacherGroupRepository.UpdateAsync(teacherGroup);

                if (!teacherGroupUpdated) throw new Exception("Could not update the teacher group.");

                Logger.SuccessConsole("Teacher group Updated Successfully.");

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        private async Task GetTeacherGroupDetailsAsync(TeacherGroup teacherGroup)
        {
            Teacher teacher = await _teacherRepository.GetByIdAsync(teacherGroup.TeacherId) ?? throw new EntityNotFoundException("Teacher Not Found");

            Subject subject = await _subjectRepository.GetByIdAsync(teacherGroup.SubjectId) ?? throw new EntityNotFoundException("Subject Not Found");

            Console.WriteLine($"Id: {teacherGroup.Id} - Teacher Fin: {teacher.FinCode} - Subject: {subject.Name}");
        }

        private async Task<(int teacherId, int groupId, int subjectId)> GetTeacherGroupDataAsync()
        {
            int teacherId = (int)Utilities.ReadNumber("Enter the Id of the teacher: ");
            _ = await _teacherRepository.GetByIdAsync(teacherId) ?? throw new EntityNotFoundException("Teacher Not Found");

            int subjectId = (int)Utilities.ReadNumber("Enter the Id of the subject: ");
            _ = await _subjectRepository.GetByIdAsync(subjectId) ?? throw new EntityNotFoundException("Subject Not Found");

            int groupId = (int)Utilities.ReadNumber("Enter the Id of the group: ");
            _ = await _groupRepository.GetByIdAsync(groupId) ?? throw new EntityNotFoundException("Group Not Found.");

            return (teacherId, groupId, subjectId);
        }
    }
}
