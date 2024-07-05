using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context) {}

        public async Task<List<Student>> GetAllWithGroups()
        {
            return await _context.Students.Include(m=>m.StudentGroups).ThenInclude(m=>m.Group).ToListAsync();
        }
    }
}
