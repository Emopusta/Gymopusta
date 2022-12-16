using Application.Features.Descriptions.Models;
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
        public Task<GIF> GetMoveGIFByMoveId(int id);
        public Task<DescriptionListModel> GetDescriptionsByMoveId(int id);
    }
}
