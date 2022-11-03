using Application.Features.Descriptions.Dtos;
using Application.Features.Moves.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Descriptions.Models
{
    public class DescriptionListModel : BasePageableModel
    {
        public IList<DescriptionListDto> Items { get; set; }
    }
}
