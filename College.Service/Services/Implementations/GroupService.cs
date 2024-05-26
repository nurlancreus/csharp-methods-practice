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
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository = new GroupRepository();
        private readonly ITeacherRepository _teacherRepository = new TeacherRepository();
        private readonly ITeacherGroupRepository _teacherGroupRepository = new TeacherGroupRepository();
        public async Task AddAsync()
        {
            Console.WriteLine("Add Group\n");
            (string name, string description) = await GetGroupDataAsync();

            Group group = new() { Name = name, Description = description, CreatedAt = DateTime.Now };
            await _groupRepository.AddAsync(group);
            Logger.SuccessConsole("Group added Successfully.");
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Delete Group\n");
            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the group you want to delete: ");
                bool groupDeleted = await _groupRepository.DeleteAsync(id);

                if (!groupDeleted) throw new EntityNotFoundException("Could not delete the group.");
                Logger.SuccessConsole("Group Deleted Successfully.");

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            Console.WriteLine("Get All Groups\n");
            List<Group> groups = await _groupRepository.GetAllAsync();

            try
            {
                if (groups.Count == 0) throw new Exception("There are no group in the repo.");

                foreach (Group group in groups)
                {
                    Console.WriteLine(group);
                }
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

        }

        public async Task GetAsync()
        {
            Console.WriteLine("Get Group\n");
            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the group you want to get: ");
                Group group = await _groupRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Group Not Found.");

                Console.WriteLine(group);

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetGroupTeachersAsync()
        {
            List<TeacherGroup> teacherGroups = await _teacherGroupRepository.GetAllAsync();

            try
            {
                if (teacherGroups.Count == 0) throw new Exception($"There are no Teacher group data now");

                int id = (int)Utilities.ReadNumber($"Enter the Id of the group you want to get teachers of: ");
                Group group = await _groupRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Group Not Found.");

                List<TeacherGroup> foundteacherGroups = teacherGroups.FindAll(tg => tg.GroupId == id);

                if (foundteacherGroups.Count == 0) throw new Exception($"Group \"{group.Name}\" got no teachers now.");

                Console.WriteLine($"Get Teachers: ");

                for (int i = 0; i < foundteacherGroups.Count; i++)
                {
                    TeacherGroup teacherGroup = foundteacherGroups[i];

                    Teacher teacher = await _teacherRepository.GetByIdAsync(teacherGroup.TeacherId) ?? throw new EntityNotFoundException("Teacher Not Found.");
                    Console.WriteLine($"{i + 1}. {teacher.FirstName + " " + teacher.LastName} - ({teacher.FinCode})");

                }
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task UpdateAsync()
        {
            Console.WriteLine("Update Group\n");
            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the group you want to update: ");
                Group group = await _groupRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException("Group Not Found.");
                (string name, string description) = await GetGroupDataAsync();

                group.Name = name;
                group.Description = description;
                group.UpdatedAt = DateTime.Now;

                bool groupUpdated = await _groupRepository.UpdateAsync(group);

                if (!groupUpdated) throw new EntityNotFoundException("Could not update the group.");
                Logger.SuccessConsole("Group Updated Successfully.");

            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        private async Task<(string name, string description)> GetGroupDataAsync()
        {
            string name = Utilities.ReadString("Enter group's name: ");
            string description = Utilities.ReadString("Enter group's description: ");

            return await Task.FromResult((name, description));
        }
    }
}
