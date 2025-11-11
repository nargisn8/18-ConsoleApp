using Academy.Domain.Entities;
using Academy.Repository.Repositories.Implimentation;
using Academy.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy.Service.Services.Implimentations
{
    public class StudentService : IStudentService
    {
        private StudentRepository _studentRepository;
        private int _count = 1;
        private GroupRepository _groupRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
            _groupRepository = new GroupRepository();
        }
        public Student Create(int groupId, Student student)
        {
            var group = _groupRepository.Get(g=>g.Id == groupId);

            if (group is null) return null;

            student.Id = _count;
            
            student.Group = group;

            _studentRepository.Create(student);

            _count++;
            return student;

        }

        public void Delete(int groupId) 
        {
            Student student = GetStudentById(groupId);

            _studentRepository.Delete(student);
        }

        public Student GetStudentById(int Id)
        {
            Student student = _studentRepository.GetStudentById(s => s.Id == Id);

            if (student is null) return null;

            return student;
        }
        public List<Student> GetAllStudentsByGroupId(int groupid)
        {
            return _studentRepository.GetAll(s => s.Group.Id == groupid);
        }
        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
    }
}
