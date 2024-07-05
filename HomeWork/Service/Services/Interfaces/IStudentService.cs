using Service.DTOs.Groups;
using Service.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Task Create(StudentCreateDto student);
        Task Update(int id, StudentEditDto student);
        Task Delete(int id);
        Task<IEnumerable<StudentDto>> GetAll();
        Task<StudentDto> GetById(int id);
    }
}
