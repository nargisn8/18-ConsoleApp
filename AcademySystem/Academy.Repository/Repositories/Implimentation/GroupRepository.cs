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

        public void Delete(Group data)
        {
            AppDbContext<Group>.datas.Remove(data);
        }

        public Group Get(Predicate<Group> predicate)
        {
            return predicate != null ? AppDbContext<Group>.datas.Find(predicate) : null;

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

        public void Update(Group data)
        {
            throw new NotImplementedException();
        }
    }
}
