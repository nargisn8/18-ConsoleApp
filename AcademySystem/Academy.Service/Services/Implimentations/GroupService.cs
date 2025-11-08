using Academy.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Domain.Entities;
using Academy.Repository.Repositories.Implimentation;


namespace Academy.Service.Services.Implimentations
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count = 1;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }
        public Group Create(Group group)
        {
            group.Id = _count;

            _groupRepository.Create(group);

            _count++;

            return group;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllGroups()
        {
            return _groupRepository.GetAllGroups();
        }

        public List<Group> GetAllGroupsByRoom(int room)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllGroupsByTeacher(string teacher)
        {
            return _groupRepository.GetAllGroupsByTeacher(g=>g.Teacher == teacher);
            
        }

        public Group GetGroupById(int id)
        {
            Group group = _groupRepository.Get(g=>g.Id == id);

            if (group is null) return null;
             
            return group; 
        }

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
