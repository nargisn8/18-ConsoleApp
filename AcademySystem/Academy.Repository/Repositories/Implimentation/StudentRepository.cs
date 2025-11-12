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

        public Student GetStudentByAge(Predicate<Student> predicate)
        {
            return predicate != null ? AppDbContext<Student>.datas.Find(predicate) : null;
        }

        public void Update(Student data)
        {
            Student dbgroup = Get(s => s.Id == data.Id);
            if (!string.IsNullOrEmpty(data.Name))
            {
                data.Name = dbgroup.Name;
            }

            if (!string.IsNullOrEmpty(data.Surname))
            {   
                data.Surname = dbgroup.Surname;
            }

            if (!string.IsNullOrEmpty(data.Age.ToString()))
            {
                data.Age = dbgroup.Age;
            }
            if (!string.IsNullOrEmpty(data.Group.Name))
            {
                data.Group.Name = dbgroup.Group.Name;
            }
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

        public void DeleteStudent(Student data)
        {
            throw new NotImplementedException();
        }

        List<Student> IRepository<Student>.GetStudentByAge(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

       
    }
}
