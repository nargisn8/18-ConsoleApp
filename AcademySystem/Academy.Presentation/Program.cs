using Academy.Presentation.Helpers;
using Academy.Service.Services.Implimentations;
using Academy.Domain.Entities;
using System.Xml.Linq;
using Academy.Presentation.Controllers;

namespace Academy.Presentation
{
    internal class Program
    {

        static void Main(string[] args)
        {
            GroupController groupController = new GroupController();
            StudentController studentController = new StudentController();

            Helper.PrintConsole(ConsoleColor.Magenta, "Select one option");
            GetMenus();

            while (true)
            {
                string selectOption = Console.ReadLine();
                int selectTrueOption;
                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);
                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case (int)Menus.CreateGroup:
                            groupController.Create();
                            break;
                        case (int)Menus.Updategroup:
                            groupController.Update();
                            break;
                        case (int)Menus.Deletegroup:
                            groupController.Delete();
                            break;
                        case (int)Menus.GetGroupbyid:
                            groupController.GetGroupsById();
                                break;
                        case (int)Menus.GetAllGroupsByTeacher:
                            groupController.GetAllGroupsByTeacher();
                               break;
                        case (int)Menus.GetAllGroupsByRoom:
                            groupController.GetAllGroupsByRoom();
                                break;
                        case (int)Menus.GetAllGroups:
                            groupController.GetAllGroups();
                            break;
                        case (int)Menus.CreateStudent:
                            studentController.Create();
                            break;
                        case (int)Menus.UpdateStudent:
                            studentController.Update();
                            break;
                        case (int)Menus.GetStudentById:
                            studentController.GetStudentById();
                            break;
                        case (int)Menus.DeleteStudent:
                            studentController.Delete();
                            break;
                        case (int)Menus.GetStudentByAge:
                            studentController.GetStudentByAge();
                            break;
                        case (int)Menus.GetAllStudentsByGroupId:
                            studentController.GetAllStudentByGroupId();
                            break;
                        case (int)Menus.SearchMethodForGroupsByName:
                            groupController.SearchMethodForGroupsByName();
                              break;
                        case (int)Menus.SearchMethodForStudentsByNameOrSurname:
                            studentController.SearchMethodForStudentsByNameOrSurname();
                            break;
                          
                        

                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Select correct option type");
                }
            }


        }
        private static void GetMenus()
        {
            Helper.PrintConsole(ConsoleColor.Yellow, "1 - Create Group,\n2 - Update group,\n3 - Delete group,\n4 - Get Group by id,\n5 - Get All Groups By Teacher,\n6 - Get All Groups By Room,\n7 - Get All Groups,\n8 - Create Student,\n9 - Update Student,\n10 - Get Student By Id,\n11 - Delete Student,\n12 - Get Student By Age,\n13 - Get All Students By Group Id,\n14 - Search Method For Groups By Name,\n15 - Search Method For Students By Name Or Surname");
        }
    }
}
