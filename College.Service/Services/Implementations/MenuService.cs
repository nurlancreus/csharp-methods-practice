using College.Service.Helpers;
using College.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Service.Services.Implementations
{
    public class MenuService : IMenuService
    {
        public async Task ShowMenuAsync()
        {
            bool isOperationsDone = false;

            while (!isOperationsDone)
            {
                Console.WriteLine("Welcome to the \"Jed\" College!\n");
                Console.WriteLine("1. Groups Menu.\n" +
                    "2. Subjects Menu.\n" +
                    "3. Students Menu.\n" +
                    "4. Teachers Menu.\n" +
                    "5. Grades Menu.\n" +
                    "0. Exit");

                int userChoice = (int)Utilities.ReadNumber("Your choice: ");

                try
                {
                    switch (userChoice)
                    {
                        case 1:
                            GroupService groupService = new GroupService();
                            await Submenu(groupService);
                            break;
                        case 2:
                            SubjectService subjectService = new SubjectService();
                            await Submenu(subjectService);
                            break;
                        case 3:
                            StudentService studentService = new StudentService();
                            await Submenu(studentService);
                            break;
                        case 4:
                            TeacherService teacherService = new TeacherService();
                            await Submenu(teacherService);
                            break;
                        case 5:
                            StudentGradeService studentGradeService = new StudentGradeService();
                            await Submenu(studentGradeService);
                            break;
                        case 0:
                            isOperationsDone = true;
                            break;
                        default:
                            throw new Exception("Choose the correct option");
                    }
                }
                catch (Exception ex)
                {
                    Logger.ExceptionConsole(ex.Message);
                }
            }
        }

        private async Task Submenu<T>(T service) where T : IService
        {
            string type = typeof(T).Name;
            string serviceName = type.EndsWith("Service") ? type[..^"Service".Length] : type;
            serviceName = serviceName == "StudentGrade" ? "Student Grade" : serviceName;

            Console.WriteLine(serviceName);

            bool isOperationsDone = false;

            while (!isOperationsDone)
            {
                Console.WriteLine($"1. Add {serviceName}.\n" +
                    $"2. Update {serviceName}.\n" +
                    $"3. Delete {serviceName}.\n" +
                    $"4. Get {serviceName} by Id.\n" +
                    $"5. Get all {serviceName}s.\n" +
                    $"0. Exit \"{serviceName}\" menu.");

                int userChoice = (int)Utilities.ReadNumber("Your choice: ");

                try
                {
                    switch (userChoice)
                    {
                        case 1:
                            await service.AddAsync();
                            break;
                        case 2:
                            await service.UpdateAsync();
                            break;
                        case 3:
                            await service.DeleteAsync();
                            break;
                        case 4:
                            await service.GetAsync();
                            break;
                        case 5:
                            await service.GetAllAsync();
                            break;
                        case 0:
                            isOperationsDone = true;
                            break;
                        default:
                            throw new Exception("Choose the correct option");
                    }
                }
                catch (Exception ex)
                {
                    Logger.ExceptionConsole(ex.Message);
                }
            }
        }
    }
}
