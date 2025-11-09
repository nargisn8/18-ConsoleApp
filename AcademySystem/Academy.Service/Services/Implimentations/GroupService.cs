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
            Group group = GetGroupById(id);

            _groupRepository.Delete(group);
        }

        public List<Group> GetAllGroups()
        {
            return _groupRepository.GetAllGroups();
        }

        public List<Group> GetAllGroupsByRoom(int room)
        {
            return _groupRepository.GetAllGroups(g => g.Room == room);
        }

        public List<Group> GetAllGroupsByTeacher(string teacher)
        {
            return _groupRepository.GetAllGroups(g=>g.Teacher == teacher);
            
        }

        public Group GetGroupById(int id)
        {
            Group group = _groupRepository.Get(g=>g.Id == id);

            if (group is null) return null;
             
            return group; 
        }

        public List<Group> SearchMethodForGroupsByName(string name)
        {
            return _groupRepository.GetAllGroups(g => g.Name == name);
        }

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
