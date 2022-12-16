using Application.Features.Descriptions.Models;
using Application.Features.Moves.Dtos;
using Application.Services.MoveService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Moves.Queries.GetMoveDetailsById
{
    public class GetMoveDetailsByIdQuery : IRequest<MoveDetailsDto>
    {
        public int Id { get; set; }
        public class GetMoveDetailsByIdQueryHandler : IRequestHandler<GetMoveDetailsByIdQuery,MoveDetailsDto>
        {
            private readonly IMoveRepository _moveRepository;
            private readonly IMoveService _moveService;
            private readonly IMapper _mapper;

            public GetMoveDetailsByIdQueryHandler(IMoveRepository moveRepository, IMoveService moveService, IMapper mapper)
            {
                _moveRepository = moveRepository;
                _moveService = moveService;
                _mapper = mapper;
            }

            public async Task<MoveDetailsDto> Handle(GetMoveDetailsByIdQuery request, CancellationToken cancellationToken)
            {
                Move? move = await _moveRepository.GetAsync(m => m.Id == request.Id);

                DescriptionListModel resultDescriptions = await _moveService.GetDescriptionsByMoveId(request.Id);
                
               
                
                MoveDetailsDto moveDetailsDto = new()
                {
                    Descriptions = resultDescriptions,
                    GIFPath = "deneme",
                    MoveId= move.Id,
                    MoveName = move.MoveName
                };
                return moveDetailsDto;

            }
        }
    }
}
