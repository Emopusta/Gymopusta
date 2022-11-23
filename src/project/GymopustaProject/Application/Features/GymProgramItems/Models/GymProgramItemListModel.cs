using Application.Features.GymProgramItems.Dtos;
using Application.Features.Moves.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GymProgramItems.Models
{
    public class GymProgramItemListModel : BasePageableModel
    {
        public IList<GymProgramItemListDto> Items { get; set; }
    }
}
