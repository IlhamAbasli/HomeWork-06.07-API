using AutoMapper;
using Domain.Entities;
using Repository.Data;
using Repository.Helpers.Exceptions;
using Repository.Repository;
using Repository.Repository.Interface;
using Service.DTOs.Groups;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;
        public GroupService(IGroupRepository groupRepo, IMapper mapper)
        {
            _groupRepo = groupRepo;
            _mapper = mapper;
        }

        public async Task Create(GroupCreateDto group)
        {
            await _groupRepo.Create(_mapper.Map<Group>(group));
        }

        public async Task Delete(int id)
        {
            var existData = await _groupRepo.GetById(id);
            if(existData is null)
            {
                throw new NotFoundException("Group not found with this ID");
            }
            await _groupRepo.Delete(existData);
        }

        public async Task<IEnumerable<GroupDto>> GetAll()
        {
            var datas = await _groupRepo.GetAll();
            return _mapper.Map<IEnumerable<GroupDto>>(datas);
        }

        public async Task<GroupDto> GetById(int id)
        {
            return _mapper.Map<GroupDto>(await _groupRepo.GetById(id));
        }

        public async Task Update(int id, GroupEditDto group)
        {
            var existGroup = await _groupRepo.GetById(id);
            if(existGroup is null)
            {
                throw new NotFoundException("Group not found with this ID");
            }
            _mapper.Map(group, existGroup);
            await _groupRepo.Update(existGroup);
        }
    }
}
