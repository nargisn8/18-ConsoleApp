using Academy.Presentation.Helpers;
using Academy.Service.Services.Implimentations;
using Academy.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Entities;

namespace Academy.Presentation.Controllers
{
    public class GroupController
    {
        GroupService _groupService = new GroupService();
        public void Create()
        {
           

         Helper.PrintConsole(ConsoleColor.Blue, "Add Name");
            string groupName = Console.ReadLine();
            

        Teacher: Helper.PrintConsole(ConsoleColor.Blue, "Add Teacher");
            string groupTeacher = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(groupTeacher) || groupTeacher.Any(char.IsDigit))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Error: Can only consist of letters");

                goto Teacher;

            }

        Room: Helper.PrintConsole(ConsoleColor.Blue, "Add Room");
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
        }
        public void Delete()
        {
        DeleteText: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");
            string groupId = Console.ReadLine();

            int id;

            bool isgroupId = int.TryParse(groupId, out id);

            if (isgroupId)
            {
                List<Group> groups = _groupService.GetAllGroups();
                if(groupId == null)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found.");
                    goto DeleteText;
                }

                _groupService.Delete(id); 

                Helper.PrintConsole(ConsoleColor.Green, "Group deleted");
            }
            else 
            {
                Helper.PrintConsole(ConsoleColor.Red, "Select correct GroupId type");
                goto DeleteText;
            }
        }
        public void Update()
        {
        Groupid: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");
            string groupId = Console.ReadLine();

            int id;

            bool isgroupId = int.TryParse(groupId, out id);

            if (isgroupId)
            {
                var findGroup = _groupService.GetGroupById(id);

                if (findGroup != null)
                {
                    Helper.PrintConsole(ConsoleColor.Blue, "Add Group new name");
                    string updateName = Console.ReadLine();

                    Helper.PrintConsole(ConsoleColor.Blue, "Add Group new teacher");
                    string updateTeacher = Console.ReadLine();

                Room: Helper.PrintConsole(ConsoleColor.Blue, "Add Group new room");
                    string updateRoom = Console.ReadLine();

                    int room;

                    bool isgroupRoom = int.TryParse(updateRoom, out room);

                    if (isgroupRoom || updateRoom == "" || updateName == "" || updateTeacher == "")
                    {
                        bool isRoomEmpty = string.IsNullOrEmpty(updateRoom);
                        bool isNameEmpty = string.IsNullOrEmpty(updateName);
                        bool isTeacherEmpty = string.IsNullOrEmpty(updateTeacher);

                        if (isRoomEmpty)
                        {
                            room = findGroup.Room;
                        }
                        if (isNameEmpty)
                        {
                            updateName = findGroup.Name;
                        }
                        if(isTeacherEmpty)
                        {
                            updateTeacher = findGroup.Teacher;
                        }
                        Group group = new Group { Name = updateName, Teacher = updateTeacher, Room = room };

                        var resultGroup = _groupService.Update(id, group);

                        if (resultGroup == null)
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Group not found, please try again.");
                            goto Groupid;
                        }
                        else
                        {
                            Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                        }
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Add correct room type");
                        goto Room;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found");
                    goto Groupid;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct Groupid type");
                goto Groupid;
            }
           
           
        }
        public void GetGroupsById()
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
        }
        public void GetAllGroupsByTeacher()
        {
        Teacher: Helper.PrintConsole(ConsoleColor.Blue, "Add Teacher");
            string groupTeacher = Console.ReadLine();
            int teacher;

            bool isteacherSearchInt = int.TryParse(groupTeacher, out teacher);

            if (!isteacherSearchInt)
            {
                List<Group> groups = _groupService.GetAllGroupsByTeacher(groupTeacher);

                if (groups.Count == 0)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "There is no data found");

                    return;
                }

                foreach (Group group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Incorrect search type");
                goto Teacher;

            }
        }
        public void GetAllGroupsByRoom()
        {
        Room: Helper.PrintConsole(ConsoleColor.Blue, "Add Room Number");
            string groupRoom = Console.ReadLine();
            int room;

            bool grouproom = int.TryParse(groupRoom, out room);

            if (grouproom)
            {
                List<Group> groups = _groupService.GetAllGroupsByRoom(room);

                if (groups.Count == 0)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "There is no data found");

                    return;
                }

                foreach (Group group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Incorrect search type");
                goto Room;

            }
        }
        public void GetAllGroups()
        {
            List<Group> allgroups = _groupService.GetAllGroups();
            foreach (var group in allgroups)
            {
                Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
            }
        }
        public void SearchMethodForGroupsByName()
        {
        SearchText: Helper.PrintConsole(ConsoleColor.Blue, "Add Group search text");

            string search = Console.ReadLine();

            List<Group> searchGroups = _groupService.SearchMethodForGroupsByName(search);

            if (searchGroups.Count != 0)
            {
                foreach (var group in searchGroups)
                {
                    Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Group Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group not found.");
                goto SearchText;
            }
        }

    }
}
