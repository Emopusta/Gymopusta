using Application.Features.MoveAreas.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoveAreas.Models
{
    public class MoveAreaListModel : BasePageableModel
    {
        public IList<MoveAreaListDto> Items { get; set; }
    }
}
