using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GymProgramItem : Entity
    {
        public int GymProgramId { get; set; }
        public int MoveId { get; set; }
        public string Reps { get; set; }
        public string Sets { get; set; }
        public string RestTime { get; set; }


    }
}
