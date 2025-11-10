using Academy.Repository.Data;
using Academy.Repository.Exceptions;
using Academy.Repository.Repositories.Interfaces;
using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Academy.Repository.Repositories.Implimentation
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Data not found!");
                AppDbContext<Student>.datas.Add(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void Delete(Student data)
        {
            throw new NotImplementedException();
        }

        public Student Get(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllGroups(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllGroupsByRoom(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAllGroupsByTeacher(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }
    }
}
