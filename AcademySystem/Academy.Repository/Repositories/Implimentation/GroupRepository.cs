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
            throw new NotImplementedException();
        }

        public Group Get(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Group data)
        {
            throw new NotImplementedException();
        }
    }
}
