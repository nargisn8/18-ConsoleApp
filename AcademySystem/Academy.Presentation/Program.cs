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

            Helper.PrintConsole(ConsoleColor.Magenta, "Select one option");
            Helper.PrintConsole(ConsoleColor.Yellow, "1 - Create Group,\n2 - Update group,\n3 - Delete group,\n4 - Get Group by id,\n5 - Get All Groups By Teacher,\n6 - Get All Groups By Room,\n7 - Get All Groups,\n8 - Create Student,\n9 - Update Student,\n10 - Get Student By Id,\n11 - Delete Student,\n12 - Get Student By Age,\n13 - Get All Students By Group Id,\n14 - Search Method For Groups By Name,\n15 - Search Method For Students By Name Or Surname");

            while (true)
            {
                string selectOption = Console.ReadLine();
                int selectTrueOption;
                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);
                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case 1:
                            groupController.Create();
                            break;
                        case 3:
                            groupController.Delete();
                            break;
                        case 4:
                            groupController.GetGroupsById();
                                break;
                        case 5:
                            groupController.GetAllGroupsByTeacher();
                               break;
                        case 6:
                            
                            groupController.GetAllGroupsByRoom();
                                break;
                        case 7:
                            groupController.GetAllGroups();
                            break;
                        case 14:
                            groupController.SearchMethodForGroupsByName();
                              break;
                           
                        

                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Select correct option type");
                }
            }
        }
    }
}
