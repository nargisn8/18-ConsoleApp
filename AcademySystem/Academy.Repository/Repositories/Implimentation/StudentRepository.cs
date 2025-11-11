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

        public void CreateStudent(Student data)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student data)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student data)
        {
            AppDbContext<Student>.datas.Remove(data);
        }

        public Student GetStudentById(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
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

        public List<Student> GetAllStudentsByGroupId(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }

        public List<Student> GetStudentByAge(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Student> SearchMethodForGroupsByName(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Student> SearchMethodForStudentsByNameOrSurname(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Student data)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student data)
        {
            throw new NotImplementedException();
        }

        public Student Get(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }
        public List<Student> GetAll(Predicate<Student> predicate = null)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }
    }
}
