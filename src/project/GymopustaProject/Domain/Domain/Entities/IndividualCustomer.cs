using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IndividualCustomer : Customer
    {
        public bool IsVIP { get; set; }

        public IndividualCustomer()
        {

        }

        public IndividualCustomer(int id,int userId, string phoneNumber, int bodyWeight, int height, bool isVIP):base(id, userId, phoneNumber, bodyWeight, height)
        {
            IsVIP = isVIP;
        }
    }
}
