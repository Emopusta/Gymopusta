using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Move : Entity
    {
        public int MoveAreaId { get; set; }
        public string MoveName { get; set; }
        public string Description { get; set; }
        public virtual MoveArea? MoveArea { get; set; }

        public Move()
        {
        }

        public Move(int id,int moveAreaId, string moveName, string description)
        {
            Id = id;
            MoveAreaId = moveAreaId;
            MoveName = moveName;
            Description = description;
        }
    }
}
