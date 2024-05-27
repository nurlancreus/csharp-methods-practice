using College.Core.Models;
using College.Data.Repositories.Implementations;
using College.Data.Repositories.Interfaces;
using College.Service.Helpers;
using College.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace College.Service.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository = new SubjectRepository();
        public async Task AddAsync()
        {
            Console.WriteLine("Add Subject\n");
            string subjectName = Utilities.ReadString("Enter subject's name: ");

            Subject subject = new () { Name = subjectName };

            await _subjectRepository.AddAsync(subject);
            Logger.SuccessConsole("Subject Added Successfully.");
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Delete Subject\n");
            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the subject you want to delete: ");

                bool subjectDeleted = await _subjectRepository.DeleteAsync(id);

                if (!subjectDeleted) throw new Exception("Subject could not be deleted");
                Logger.SuccessConsole("Subject Deleted Successfully.");
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }

        }

        public async Task GetAllAsync()
        {
            Console.WriteLine("Get All Subjects\n");
            List<Subject> subjects = await _subjectRepository.GetAllAsync();

            try
            {
                if (subjects.Count == 0) throw new Exception("There are no subject in the repo.");
                foreach (Subject subject in subjects)
                {
                    Console.WriteLine(subject);
                }
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task GetAsync()
        {
            Console.WriteLine("Get Subject\n");
            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the subject you want to get: ");
                Subject subject = await _subjectRepository.GetByIdAsync(id) ?? throw new EntryPointNotFoundException("Subject Not Found");

                Console.WriteLine(subject);
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }

        public async Task UpdateAsync()
        {
            Console.WriteLine("Update Subject\n");

            try
            {
                int id = (int)Utilities.ReadNumber("Enter the Id of the subject you want to update: ");
                Subject subject = await _subjectRepository.GetByIdAsync(id) ?? throw new EntryPointNotFoundException("Subject Not Found");

                string subjectName = Utilities.ReadString("Enter subject's name: ");

                subject.Name = subjectName;
                subject.UpdatedAt = DateTime.Now;

                bool subjectUpdated = await _subjectRepository.UpdateAsync(subject);

                if (!subjectUpdated) throw new Exception("Subject could not be updated");
                Logger.SuccessConsole("Subject Updated Successfully.");
            }
            catch (Exception ex)
            {
                Logger.ExceptionConsole(ex.Message);
            }
        }
    }
}
