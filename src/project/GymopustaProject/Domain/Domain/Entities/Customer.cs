using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public int BodyWeight { get; set; }
        public int Height { get; set; }
        public Customer()
        {
        }

        public Customer(int id,int userId, string phoneNumber, int bodyWeight, int height)
        {
            Id = id;
            UserId = userId;
            PhoneNumber = phoneNumber;
            BodyWeight = bodyWeight;
            Height = height;
        }
    }
}
