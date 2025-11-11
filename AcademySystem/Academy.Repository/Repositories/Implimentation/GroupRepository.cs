using Academy.Repository.Exceptions;
using Academy.Repository.Repositories.Interfaces;
using Academy.Domain.Entities;
using Academy.Repository.Data;


namespace Academy.Repository.Repositories.Implimentation
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Data not found!");
                AppDbContext<Group>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateStudent(Group data)
        {
            throw new NotImplementedException();
        }

        public void Delete(Group data)
        {
            AppDbContext<Group>.datas.Remove(data);
        }

        public void DeleteStudent(Group data)
        {
            throw new NotImplementedException();
        }

        public Group Get(Predicate<Group> predicate)
        {
            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;

        }

        public List<Student> GetAll(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllGroups(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public List<Group> GetAllGroupsByRoom(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public List<Group> GetAllGroupsByTeacher(Predicate<Group> predicate = null)
        {
            return predicate != null ? AppDbContext<Group>.datas.FindAll(predicate) : AppDbContext<Group>.datas;
        }

        public List<Group> GetAllStudentsByGroupId(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetStudentByAge(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> SearchMethodForGroupsByName(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> SearchMethodForStudentsByNameOrSurname(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Group data)
        {
            Group dbgroup = Get(g => g.Id == data.Id);
            if (!string.IsNullOrEmpty(data.Name))
            {
                data.Name = dbgroup.Name;
            }

            if (!string.IsNullOrEmpty(data.Teacher))
            {
                data.Teacher = dbgroup.Teacher;
            }

            if (!string.IsNullOrEmpty(data.Room.ToString()))
            {
                data.Room = dbgroup.Room;
            }
        }

        public void UpdateStudent(Group data)
        {
            throw new NotImplementedException();
        }
    }
}
