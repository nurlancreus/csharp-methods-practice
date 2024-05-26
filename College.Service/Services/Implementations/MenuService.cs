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
                Console.WriteLine("\n*******************************\n" +
                    "*******************************\n" +
                    "*******************************\n");

                Console.WriteLine("Welcome to the \"Jed\" College!\n");
                Console.WriteLine("1. Groups Menu.\n" +
                    "2. Subjects Menu.\n" +
                    "3. Students Menu.\n" +
                    "4. Teachers Menu.\n" +
                    "5. Grades Menu.\n" +
                    "6. Teacher Group relations menu.\n" +
                    "0. Exit");

                int userChoice = (int)Utilities.ReadNumber("\nYour choice: ");

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
                        case 6:
                            TeacherGroupService teacherGroupService = new TeacherGroupService();
                            await Submenu(teacherGroupService);
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

        private static async Task Submenu<T>(T service) where T : IService
        {
            string type = typeof(T).Name;
            string serviceName = type.EndsWith("Service") ? type[..^"Service".Length] : type;
            serviceName = serviceName switch
            {
                "StudentGrade" => "Student Grade",
                "TeacherGroup" => "Teacher Group relations",
                _ => serviceName
            };

            Console.WriteLine("\n*******************************\n");
            Console.WriteLine($"\"{serviceName}\" Menu\n");

            string extraChoice = serviceName switch
            {
                "Student" => $"6. Get {serviceName}'s grades.\n",
                "Group" => $"6. Get {serviceName}'s teachers.\n",
                "Teacher" => $"6. Get {serviceName}'s groups.\n" +
                             $"7. Get {serviceName}'s subjects.\n",
                _ => ""
            };

            bool isOperationsDone = false;

            while (!isOperationsDone)
            {
                Console.WriteLine($"1. Add {serviceName}.\n" +
                    $"2. Update {serviceName}.\n" +
                    $"3. Delete {serviceName}.\n" +
                    $"4. Get {serviceName} by Id.\n" +
                    $"5. Get all {serviceName}s.\n" +
                    extraChoice +
                    $"0. Exit \"{serviceName}\" menu.");

                int userChoice = (int)Utilities.ReadNumber("\nYour choice: ");

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
                        case 6:
                            await HandleExtraChoice(service, serviceName);
                            break;
                        case 7:
                            if (serviceName == "Teacher")
                            {
                                if (service is ITeacherService teacherService)
                                {
                                    await teacherService.GetTeacherGroupsAsync("subjects");
                                }
                                else
                                {
                                    throw new Exception("Invalid service type for teacher subjects operation");
                                }
                            }
                            else
                            {
                                throw new Exception("Choose the correct option");
                            }
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

        private static async Task HandleExtraChoice<T>(T service, string serviceName) where T : IService
        {
            if (serviceName == "Student" || serviceName == "Group" || serviceName == "Teacher")
            {
                if (service is IStudentService studentService)
                {
                    await studentService.GetStudentGradesAsync();
                }
                else if (service is IGroupService groupService)
                {
                    await groupService.GetGroupTeachersAsync();
                }
                else if (service is ITeacherService teacherService)
                {
                    await teacherService.GetTeacherGroupsAsync("groups");
                }
                else
                {
                    throw new Exception("Invalid service type for extra operation");
                }
            }
            else throw new Exception("Choose the correct option");

        }
    }
}
