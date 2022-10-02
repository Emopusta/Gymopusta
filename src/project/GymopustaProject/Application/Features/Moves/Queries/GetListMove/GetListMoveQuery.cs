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

namespace Application.Features.Moves.Queries.GetListMove
{
    public class GetListMoveQuery : IRequest<MoveListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListMoveQueryHandler : IRequestHandler<GetListMoveQuery, MoveListModel>
        {
            private readonly IMoveRepository _moveRepository;
            private readonly IMapper _mapper;

            public GetListMoveQueryHandler(IMoveRepository moveRepository, IMapper mapper)
            {
                _moveRepository = moveRepository;
                _mapper = mapper;
            }

            public async Task<MoveListModel> Handle(GetListMoveQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Move> moves = await _moveRepository.GetListAsync(
                    index: request.PageRequest.Page, 
                    size: request.PageRequest.PageSize);
                MoveListModel mappedMoveListModel = _mapper.Map<MoveListModel>(moves);
                return mappedMoveListModel;
            }
        }
    }
}
