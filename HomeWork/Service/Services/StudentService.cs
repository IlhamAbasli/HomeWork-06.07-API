using AutoMapper;
using Domain.Entities;
using Repository.Helpers.Exceptions;
using Repository.Repository.Interface;
using Service.DTOs.Students;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepo,
                              IMapper mapper)
        {
            _mapper = mapper;
            _studentRepo = studentRepo; 
        }

        public async Task Create(StudentCreateDto student)
        {
            Student newStudent = new()
            {
                FullName = student.Fullname,
                Address = student.Address,
                Email = student.Email,
                Age = student.Age,
            };
            newStudent.StudentGroups.Add(new StudentGroup()
            {
                Student = newStudent,
                GroupId = student.GroupId,
            });
            await _studentRepo.Create(newStudent);
        }

        public async Task Delete(int id)
        {
            var existData = await _studentRepo.GetById(id);
            if (existData is null) throw new NotFoundException("Student not found with this ID");

            await _studentRepo.Delete(existData);
        }

        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _studentRepo.GetAll());
        }

        public async Task<StudentDto> GetById(int id)
        {
            return _mapper.Map<StudentDto>(await _studentRepo.GetById(id));
        }

        public async Task Update(int id, StudentEditDto student)
        {
            var existData = await _studentRepo.GetById(id);
            if (existData is null) throw new NotFoundException("Student not found with this ID");
            _mapper.Map(student, existData);
            await _studentRepo.Update(existData);
        }
    }
}
