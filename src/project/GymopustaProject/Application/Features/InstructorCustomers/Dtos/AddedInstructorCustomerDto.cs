using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InstructorCustomers.Dtos
{
    public class AddedInstructorCustomerDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public int BodyWeight { get; set; }
        public int Height { get; set; }
        public int BranchId { get; set; }
    }
}
