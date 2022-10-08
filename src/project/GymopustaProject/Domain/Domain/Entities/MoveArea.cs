using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MoveArea : Entity
    {
        public string MoveAreaName { get; set; }
        public virtual ICollection<Move>? Moves { get; set; }

        public MoveArea()
        {

        }

        public MoveArea(int id,string moveAreaName)
        {
            Id = id;
            MoveAreaName = moveAreaName;
        }
    }
}
