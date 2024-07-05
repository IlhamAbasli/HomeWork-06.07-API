using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<List<Student>> GetAllWithGroups();
    }
}
