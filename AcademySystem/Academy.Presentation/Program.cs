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
                            {
                            Name: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Name");
                                string groupName = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(groupName) || groupName.Any(char.IsDigit))
                                {
                                    Helper.PrintConsole(ConsoleColor.Red, "Error: The name can only consist of letters");

                                    goto Name;

                                }

                            Teacher: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Teacher");
                                string groupTeacher = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(groupTeacher) || groupTeacher.Any(char.IsDigit))
                                {
                                    Helper.PrintConsole(ConsoleColor.Red, "Error: Can only consist of letters");

                                    goto Teacher;

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
                        case 4:
                            {
                            Groupid: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");
                                string groupId = Console.ReadLine();

                                int id;

                                bool isgroupId = int.TryParse(groupId, out id);

                                if (isgroupId)
                                {
                                    Group group = _groupService.GetGroupById(id);

                                    if (group != null)
                                    {
                                        Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                                    }
                                    else
                                    {
                                        Helper.PrintConsole(ConsoleColor.Red, "Group not found");
                                        goto Groupid;
                                    }


                                }
                                else
                                {
                                    Helper.PrintConsole(ConsoleColor.Red, "Select correct groupid type");
                                    goto Groupid;
                                }
                                break;
                            }
                        case 5:
                            {

                            Teacher: Helper.PrintConsole(ConsoleColor.Blue, "Add Teacher");
                                string teacherSearch = Console.ReadLine();
                                int teacherSearchInt;

                                bool isteacherSearchInt = int.TryParse(teacherSearch, out teacherSearchInt);

                                if (!isteacherSearchInt)
                                {
                                    List<Group> groups = _groupService.GetAllGroupsByTeacher(teacherSearch);

                                    if(groups.Count == 0)
                                    {
                                        Helper.PrintConsole(ConsoleColor.Red, "There is no data found");

                                        return;
                                    }

                                    foreach(Group group in groups)
                                    {
                                        Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                                    }
                                }
                                else
                                {
                                    Helper.PrintConsole(ConsoleColor.Red, "Incorrect search type");
                                    goto Teacher;

                                }
                                    break;
                            }
                        case 7:
                            {
                                List<Group> allgroups = _groupService.GetAllGroups();
                                foreach (var group in allgroups)
                                {
                                    Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                                }
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
