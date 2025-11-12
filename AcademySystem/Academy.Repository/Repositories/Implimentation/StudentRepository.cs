using Academy.Domain.Entities;
using Academy.Repository.Data;
using Academy.Repository.Exceptions;
using Academy.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Academy.Repository.Repositories.Implimentation
{
    public class StudentRepository : IRepository<Student>
    {
        private List<Student> _students;
        public List<Student> students = new List<Student>();
       
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
            Student student = GetStudentById(s => s.Id == data.Id);

            if (!string.IsNullOrWhiteSpace(data.Name))
            {
                student.Name = data.Name;
            }
            else if (!string.IsNullOrWhiteSpace(data.Surname))
            {
                student.Surname = data.Surname;
            }
            else if (!string.IsNullOrWhiteSpace(data.Age.ToString()))
            {
                student.Age = data.Age;
            }
        }
        public Student Get(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }
        public List<Student> GetAll(Predicate<Student> predicate = null)
        {
            return predicate != null ? AppDbContext<Student>.datas.FindAll(predicate) : AppDbContext<Student>.datas;
        }
        List<Student> IRepository<Student>.GetStudentByAge(Predicate<Student> predicate)
        {
            throw new NotImplementedException();
        }

        
    }
}
