using Domain.Entities;
using Repository.Repository.Interface;
using Service.DTOs.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Task Create(GroupCreateDto group);
        Task Update(int id, GroupEditDto group);
        Task Delete(int id);
        Task<IEnumerable<GroupDto>> GetAll();
        Task<GroupDto> GetById(int id);
    }
}
