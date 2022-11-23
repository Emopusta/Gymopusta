using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Dtos
{
    public class AddedIndividualCustomerDto
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public int BodyWeight { get; set; }
        public int Height { get; set; }
        public bool IsVIP { get; set; }
    }
}
