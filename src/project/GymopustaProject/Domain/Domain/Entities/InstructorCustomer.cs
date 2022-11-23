using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InstructorCustomer : Customer
    {
        public string? Education { get; set; }
        public string Branch { get; set; }

        public InstructorCustomer()
        {
        }

        public InstructorCustomer(int id, int userId, string phoneNumber, int bodyWeight, int height, string? education, string branch) : base(id,userId, phoneNumber, bodyWeight, height)
        {
            Education = education;
            Branch = branch;
        }
    }
}
