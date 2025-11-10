using Academy.Domain.Entities;
using Academy.Repository.Repositories.Implimentation;
using Academy.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
