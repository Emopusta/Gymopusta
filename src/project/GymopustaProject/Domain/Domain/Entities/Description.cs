using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Description : Entity
    {
        public int MoveId { get; set; }
        public string DescriptionText { get; set; }

        public virtual Move? Move { get; set; }

        public Description()
        {

        }
        public Description(int id, int moveId, string descriptionText)
        {
            Id = id;
            MoveId = moveId;
            DescriptionText = descriptionText;
        }
    }
}
