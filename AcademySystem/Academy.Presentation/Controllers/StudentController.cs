using Academy.Domain.Entities;
using Academy.Presentation.Helpers;
using Academy.Service.Services.Implimentations;
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

        }
        public void Delete() 
        { 

        }
        public void GetStudentByAge()
        {

        }
        public void GetAllStudentByGroupId()
        {

        }
        public void SearchMethodForStudentsByNameOrSurname()
        {

        }

    }
}
