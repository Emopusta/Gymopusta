using Application.Features.MoveAreas.Dtos;
using Application.Features.MoveAreas.Models;
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

namespace Application.Features.MoveAreas.Queries.GetListMoveArea
{
    public class GetListMoveAreaQuery : IRequest<MoveAreaListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListMoveAreaQueryHandler : IRequestHandler<GetListMoveAreaQuery, MoveAreaListModel>
        {
            private readonly IMoveAreaRepository _moveAreaRepository;
            private readonly IMapper _mapper;

            public GetListMoveAreaQueryHandler(IMoveAreaRepository moveAreaRepository, IMapper mapper)
            {
                _moveAreaRepository = moveAreaRepository;
                _mapper = mapper;
            }

            public async Task<MoveAreaListModel> Handle(GetListMoveAreaQuery request, CancellationToken cancellationToken)
            {
                IPaginate<MoveArea> moveAreas = await _moveAreaRepository.GetListAsync(size: request.PageRequest.PageSize,
                    index: request.PageRequest.Page);
                MoveAreaListModel mappedResult = _mapper.Map<MoveAreaListModel>(moveAreas);
                return mappedResult;
            }
        }
    }
}
