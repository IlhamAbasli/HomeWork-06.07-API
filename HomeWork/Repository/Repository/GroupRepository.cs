﻿using Domain.Entities;
using Repository.Data;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GroupRepository : BaseRepository<Group>,IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context) { }
    }
}
