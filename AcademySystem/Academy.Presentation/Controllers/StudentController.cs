using Academy.Domain.Entities;
using Academy.Presentation.Helpers;
using Academy.Repository.Repositories.Implimentation;
using Academy.Service.Services.Implimentations;
using Academy.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Group = Academy.Domain.Entities.Group;

namespace Academy.Presentation.Controllers
{
    public class StudentController
    {
        StudentService _studentService = new StudentService();
        GroupService _groupService = new GroupService();
        StudentRepository _studentRepository = new StudentRepository();
        public void Create()
        {
            List<Group> groups = _groupService.GetAllGroups();

            if (groups == null || groups.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group not found.");
                return; 
            }

        GroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");

            string groupId = Console.ReadLine(); 

            int selectedGroupId;

            bool isSelectedId = int.TryParse(groupId, out selectedGroupId);

            if (isSelectedId)
            {
            Name: Helper.PrintConsole(ConsoleColor.Blue, "Add Student Name");
                string studentName = Console.ReadLine()?.Trim();

                if (studentName.Contains(' '))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: Student name cannot contain spaces!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(studentName) || studentName.Any(char.IsDigit))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: The name can only consist of letters");
                    goto Name;

                }

                studentName = char.ToUpper(studentName[0]) + studentName.Substring(1).ToLower();

            Surname: Helper.PrintConsole(ConsoleColor.Blue, "Add Student Surname");
                string studentSurname = Console.ReadLine()?.Trim();

                if (studentSurname.Contains(' '))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: Stduent surname cannot contain spaces!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(studentSurname) || studentSurname.Any(char.IsDigit))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: The surname can only consist of letters");
                    goto Surname;

                }
                studentSurname = char.ToUpper(studentSurname[0]) + studentSurname.Substring(1).ToLower();

            Age: Helper.PrintConsole(ConsoleColor.Blue, "Add Student Age");
                string studentAge = Console.ReadLine();

                int age;

                bool isstudentAge = int.TryParse(studentAge, out age);

                if (isstudentAge)
                {
                    Student student = new Student { Name = studentName, Surname = studentSurname, Age = age };

                    var result = _studentService.Create(selectedGroupId, student);

                    if (result != null)
                    {

                        if (age > 16 && age < 65)
                        {
                            Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Student Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {student.Group.Name} ");
                        }
                        else
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Error: Age is inappropriate.");
                            goto Age;
                        }
                       
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Group not found, please add correct group id.");
                        goto GroupId;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Select correct age");
                    goto Age;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Select correct GroupId type");
                goto GroupId;
            }

        }
        public void Update(int selectTrueOption)
        {
            List<Student> students = _studentService.GetAll();

            if (students.Count == 0)
            {
                Helper.PrintConsole(ConsoleColor.Red, "There is no group to update!");
                return;
            }

        FalseUpdate:
            Helper.PrintConsole(ConsoleColor.Green, "Enter the ID of the group you want to update:");
            string idStr = Console.ReadLine();

            if (int.TryParse(idStr, out int idInt))
            {
                var findStudent = _studentService.GetStudentById(idInt);
                if (findStudent == null)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "No group found with that ID!");
                    goto FalseUpdate;
                }

            FalseGroup:
                Helper.PrintConsole(ConsoleColor.Green, "Add a new group name:");
                string studentName = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(studentName) || int.TryParse(studentName, out selectTrueOption))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group name cannot be empty or numeric!");
                    goto FalseGroup;
                }

            FalseName:
                Helper.PrintConsole(ConsoleColor.Green, "Add a group teacher:");
                string studentSurname = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(studentSurname) ||
                    studentSurname.Any(char.IsDigit) ||
                    studentSurname.Contains(" "))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Teacher name cannot be empty, contain numbers, or have spaces!");
                    goto FalseName;
                }

                studentSurname = Helper.Capitalize(studentSurname);

            FalseClass:
                Helper.PrintConsole(ConsoleColor.Green, "Add a room number:");
                string age = Console.ReadLine().Trim();
                int studentAge;

                if (string.IsNullOrWhiteSpace(studentAge))
                {
                    studentAge = findStudent.Age;
                }
                else if (!int.TryParse(age, out studentAge))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Select a correct room number!");
                    goto FalseClass;
                }


               

                Group updatedGroup = new Group
                {
                    Name = studentName,
                    Surname = studentSurname,
                    Age = studentAge,
                    Group = studentGroup
                };

                _studentService.Update(idInt, updatedGroup);
                Helper.PrintConsole(ConsoleColor.DarkCyan, "Group updated successfully");
                Console.WriteLine("");
                Helper.PrintConsole(ConsoleColor.DarkCyan,
                    $"Group ID: {idInt}\nGroup name: {updatedGroup.Name}\nTeacher: {updatedGroup.Teacher}\nGroup room: {updatedGroup.Room}\n");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Incorrect ID format!");
                goto FalseUpdate;
            }
        }
       
        public void GetStudentById()
        {
        Studentid: Helper.PrintConsole(ConsoleColor.Blue, "Add Id");
            string studentId = Console.ReadLine();

            int id;

            bool isstudentid = int.TryParse(studentId, out id);

            if (isstudentid)
            {
                Student student = _studentService.GetStudentById(id);

                if (student != null)
                {
                    Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {student.Group.Name}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student not found");
                    goto Studentid;
                }


            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Select correct id type");
                goto Studentid;
            }
        }
        public void Delete()
        {
        DeleteText: Helper.PrintConsole(ConsoleColor.Blue, "Add Student Id");
            string studentId = Console.ReadLine();

            int id;

            bool isstudentId = int.TryParse(studentId, out id);

            if (isstudentId)
            {
                List<Student> students = _studentService.GetAll();

                bool found = false;

                foreach (var s in students)
                {
                    if (s.Id == id)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student not found.");
                    goto DeleteText;
                }
                _studentService.Delete(id);

                Helper.PrintConsole(ConsoleColor.Green, "Student deleted");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Select correct StudentId type");
                goto DeleteText;
            }
        }
        public void GetStudentByAge()
        {
        Studentage: Helper.PrintConsole(ConsoleColor.Blue, "Add Student age");
            string studentAge = Console.ReadLine();

            int age;

            bool isstudentage = int.TryParse(studentAge, out age);

            if (isstudentage)
            {
                Student student = _studentService.GetStudentByAge(age);

                if (student != null)
                {
                    Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {student.Group.Name}");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Student not found");
                    goto Studentage;
                }


            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Select correct id type");
                goto Studentage;
            }
        }
        public void GetAllStudentByGroupId()
        {
        GroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");
            string groupId = Console.ReadLine();
            int id;

            bool isgroupid = int.TryParse(groupId, out id);

            if (isgroupid)
            {
                List<Student> students = _studentService.GetAll();

                if (students.Count > 0 && students != null)
                {
                    bool found = false;
                    foreach (Student student in students)
                    {
                        if (student.Group.Id == id)
                        {
                            Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {student.Group.Name}");
                        }
                        found = true;
                        student.Name = char.ToUpper(student.Name[0]) + student.Name.Substring(1).ToLower();
                        student.Surname = char.ToUpper(student.Surname[0]) + student.Surname.Substring(1).ToLower();
                        student.Group.Name = char.ToUpper(student.Group.Name[0]) + student.Group.Name.Substring(1).ToLower();
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "There is no data found");

                }


            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Incorrect search type");
                goto GroupId;

            }
        }
        public void SearchMethodForStudentsByNameOrSurname()
        {
        SearchText: Helper.PrintConsole(ConsoleColor.Blue, "Add Student search text");

            string search = Console.ReadLine();

            List<Student> searchStudents = _studentService.SearchMethodForStudentsByNameOrSurname(search);

            if (searchStudents.Count != 0)
            {
                foreach (var student in searchStudents)
                {
                    Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Student Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {student.Group.Name}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Student not found.");
                goto SearchText;
            }
        }
        public void GetAll()
        {
            List<Student> allstudents = _studentService.GetAll();
            foreach (var student in allstudents)
            {
                Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {student.Group.Name}");
            }
        }
    }
}
