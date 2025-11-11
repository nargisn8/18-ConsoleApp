using Academy.Domain.Entities;
using Academy.Presentation.Helpers;
using Academy.Service.Services.Implimentations;
using Academy.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Academy.Presentation.Controllers
{
    public class StudentController
    {
        StudentService _studentService = new StudentService();
        public void Create()
        {
        GroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id");

            string groupId = Console.ReadLine();

            int selectedGroupId;

            bool isSelectedId = int.TryParse(groupId, out selectedGroupId);

            if (isSelectedId)
            {
            Name: Helper.PrintConsole(ConsoleColor.Blue, "Add Student Name");
                string studentName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(studentName) || studentName.Any(char.IsDigit))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: The name can only consist of letters");
                    goto Name;

                }

            Surname: Helper.PrintConsole(ConsoleColor.Blue, "Add Student Surname");
                string studentSurname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(studentSurname) || studentSurname.Any(char.IsDigit))
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Error: The surname can only consist of letters");
                    goto Surname;

                }
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
                        Helper.PrintConsole(ConsoleColor.DarkMagenta, $"Student Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {student.Group.Name} ");
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
        public void Update()
        {

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
        //public void Delete()
        //{
        //DeleteText: Helper.PrintConsole(ConsoleColor.Blue, "Add Student Id");
        //    string studentId = Console.ReadLine();

        //    int id;

        //    bool isstudentId = int.TryParse(studentId, out id);

        //    if (isstudentId)
        //    {
        //        List<Student> students = _studentService.GetAllStudentGroupById(id);
        //        if (studentId == null)
        //        {
        //            Helper.PrintConsole(ConsoleColor.Red, "Student not found.");
        //            goto DeleteText;
        //        }

        //        _studentService.Delete(id);

        //        Helper.PrintConsole(ConsoleColor.Green, "Student deleted");
        //    }
        //    else
        //    {
        //        Helper.PrintConsole(ConsoleColor.Red, "Select correct StudentId type");
        //        goto DeleteText;
        //    }
        //}
        public void GetStudentByAge()
        {

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
