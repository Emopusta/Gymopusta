using Application.Features.Moves.Dtos;
using Application.Features.Moves.Models;
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

namespace Application.Features.Moves.Queries.GetByMoveAreaIdMove
{
    public class GetByMoveAreaIdMoveQuery : IRequest<MoveListModel>
    {
        public PageRequest PageRequest { get; set; }
        public int MoveAreaId { get; set; }

        public class GetByMoveAreaIdMoveQueryHandler : IRequestHandler<GetByMoveAreaIdMoveQuery, MoveListModel>
        {
            private readonly IMoveRepository _moveRepository;
            private readonly IMapper _mapper;

            public GetByMoveAreaIdMoveQueryHandler(IMoveRepository moveRepository, IMapper mapper)
            {
                _moveRepository = moveRepository;
                _mapper = mapper;
            }

            public async Task<MoveListModel> Handle(GetByMoveAreaIdMoveQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Move>? move = await _moveRepository.GetListAsync(m => m.MoveAreaId == request.MoveAreaId
                , index:request.PageRequest.Page
                , size:request.PageRequest.PageSize);

                MoveListModel mappedMoveListModel = _mapper.Map<MoveListModel>(move);
                return mappedMoveListModel;
            }
        }
    }
}
