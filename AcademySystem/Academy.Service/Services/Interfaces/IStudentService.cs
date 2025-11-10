using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Service.Services.Interfaces
{
    internal interface IStudentService
    {
        Student Create(int GroupId, Student student);
    }
}
