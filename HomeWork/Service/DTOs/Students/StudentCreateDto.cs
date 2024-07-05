using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Students
{
    public class StudentCreateDto
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public byte Age { get; set; } 
        public int GroupId { get; set; }

    }
}
