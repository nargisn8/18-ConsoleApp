using Academy.Domain.Common;
using Academy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T :  BaseEntity
    {
        void Create(T data);
        void Update(T data);
        void Delete(T data);
        T Get(Predicate<T> predicate);
        List<T> GetAllGroupsByTeacher(Predicate<T> predicate);
        List<T> GetAllGroupsByRoom(Predicate<T> predicate);
        List<T> GetAllGroups(Predicate<T> predicate);
        List<T> SearchMethodForGroupsByName(Predicate<T> predicate);
        void CreateStudent(T data);
        void UpdateStudent(T data);
        void DeleteStudent(T data);
        List<T> GetStudentByAge(Predicate<T> predicate);
        List<T> GetAllStudentsByGroupId(Predicate<T> predicate);
        List<T> SearchMethodForStudentsByNameOrSurname(Predicate<T> predicate);
        List<Student> GetAll(Predicate<T> predicate );
        

    }
}
