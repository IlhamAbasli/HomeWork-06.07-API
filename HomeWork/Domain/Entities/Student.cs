using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<StudentGroup> StudentGroups { get; set; }
    }
}
