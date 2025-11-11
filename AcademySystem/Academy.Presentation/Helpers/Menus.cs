using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Presentation.Helpers
{
    public enum Menus
    {
        CreateGroup = 1,
        Updategroup = 2,
        Deletegroup = 3,
        GetGroupbyid = 4,
        GetAllGroupsByTeacher = 5,
        GetAllGroupsByRoom = 6,
        GetAllGroups = 7,
        CreateStudent = 8,
        UpdateStudent = 9,
        GetStudentById = 10,
        DeleteStudent = 11,
        GetStudentByAge = 12,
        GetAllStudentsByGroupId = 13,
        SearchMethodForGroupsByName = 14,
        SearchMethodForStudentsByNameOrSurname = 15
    }
}
