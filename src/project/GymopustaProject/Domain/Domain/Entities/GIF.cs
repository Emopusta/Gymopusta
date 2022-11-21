using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GIF : Entity
    {
        public int MoveId { get; set; }
        public string GIFPath { get; set; }
        public bool IsManual { get; set; }
        public virtual Move? Move { get; set; }

        public GIF()
        {

        }
        public GIF(int id,int moveId, string gIFPath, bool isManual)
        {
            Id = id;
            MoveId = moveId;
            GIFPath = gIFPath;
            IsManual = isManual;
        }
    }
}
