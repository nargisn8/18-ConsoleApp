using Academy.Presentation.Helpers;
using Academy.Service.Services.Implimentations;
using Academy.Domain.Entities;
using System.Xml.Linq;

namespace Academy.Presentation
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            GroupService _groupService = new GroupService();

            Helper.PrintConsole(ConsoleColor.Magenta, "Select one option");
            Helper.PrintConsole(ConsoleColor.Yellow, "1 - Create Group, 2 - Get Group by id, 3 - Update Group, 4 - Delete Group");

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
                        Name: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Name");
                            string groupName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(groupName) || groupName.Any(char.IsDigit))
                            {
                                Helper.PrintConsole(ConsoleColor.Red, "Error: The name can only consist of letters");

                                goto Name;
                                continue;
                            }

                        Teacher:  Helper.PrintConsole(ConsoleColor.Blue, "Add Group Teacher");
                            string groupTeacher = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(groupTeacher) || groupTeacher.Any(char.IsDigit))
                            {
                                Helper.PrintConsole(ConsoleColor.Red, "Error: Can only consist of letters");

                                goto Teacher;
                                continue;
                            }

                        Room: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Room");
                         string groupRoom = Console.ReadLine();
                            
                            int room;

                            bool isgroupRoom = int.TryParse(groupRoom, out room);

                            if (isgroupRoom)
                            {
                                Group group = new Group { Name = groupName, Teacher = groupTeacher, Room = room };

                                var result = _groupService.Create(group);

                                Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Group Id: {result.Id}, Name: {result.Name}, Teacher: {result.Teacher}, Room: {result.Room}");
                            }
                            else
                            {
                                Helper.PrintConsole(ConsoleColor.Red, "Select correct room");

                                goto Room;
                            }
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
