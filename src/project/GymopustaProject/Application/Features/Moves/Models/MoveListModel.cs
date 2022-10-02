using Application.Features.Moves.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Moves.Models
{
    public class MoveListModel : BasePageableModel
    {
        public IList<MoveListDto> Items { get; set; }
    }
}
