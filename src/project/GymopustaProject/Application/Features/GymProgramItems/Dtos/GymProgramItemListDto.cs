using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GymProgramItems.Dtos
{
    public class GymProgramItemListDto
    {
        public int Id { get; set; }
        public int GymProgramId { get; set; }
        public int MoveId { get; set; }
        public string Reps { get; set; }
        public string Sets { get; set; }
        public string RestTime { get; set; }
    }
}
