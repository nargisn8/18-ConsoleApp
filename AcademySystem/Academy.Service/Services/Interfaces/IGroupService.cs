using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Entities;

namespace Academy.Service.Services.Interfaces
{
    public interface IGroupService
    {
        Group Create(Group group);
        Group Update(int id,Group group);
        void Delete(int id);
        Group GetGroupById(int id);
        List<Group> GetAllGroupsByTeacher(string teacher);
        List<Group> GetAllGroupsByRoom(int room);
        List<Group> GetAllGroups();



    }
}
