using Application.Features.Descriptions.Models;
using Application.Features.GIFs.Dtos;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.MoveService
{
    public interface IMoveService
    {
        public Task<GIFListDto> GetManualMoveGIFByMoveId(int id);
        public Task<DescriptionListModel> GetDescriptionsByMoveId(int id);
    }
}
