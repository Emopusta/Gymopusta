using Application.Features.GIFs.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GIFs.Models
{
    public class GIFListModel : BasePageableModel
    {
        public IList<GIFListDto> Items { get; set; }
    }
}
