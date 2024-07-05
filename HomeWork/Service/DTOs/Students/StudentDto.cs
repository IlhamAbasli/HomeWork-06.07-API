using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Students
{
    public class StudentDto
    {
        public string Fullname { get; set; }
        public byte Age { get; set; } 
        public string Address { get; set; }
        public string Email { get; set; }
        public List<string> Groups {  get; set; }
    }
}
