using Application.Features.GymProgramItems.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GymProgramItems.Queries.GetByGymProgramIdGymProgramItem
{
    public class GetByGymProgramIdGymProgramItemQuery : IRequest<GymProgramItemListModel>
    {
        public PageRequest PageRequest { get; set; }
        public int GymProgramId { get; set; }

        public class GetByGymProgramIdGymProgramItemHandler : IRequestHandler<GetByGymProgramIdGymProgramItemQuery, GymProgramItemListModel>
        {
            private readonly IGymProgramItemRepository _gymProgramItemRepository;
            private readonly IMapper _mapper;

            public GetByGymProgramIdGymProgramItemHandler(IGymProgramItemRepository gymProgramItemRepository, IMapper mapper)
            {
                _gymProgramItemRepository = gymProgramItemRepository;
                _mapper = mapper;
            }

            public async Task<GymProgramItemListModel> Handle(GetByGymProgramIdGymProgramItemQuery request, CancellationToken cancellationToken)
            {
                 IPaginate<GymProgramItem> GymProgramItems= await _gymProgramItemRepository.GetListAsync(p => p.GymProgramId == request.GymProgramId,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                GymProgramItemListModel mappedResult = _mapper.Map<GymProgramItemListModel>(GymProgramItems);
                return mappedResult;

            }
        }
    }
}
