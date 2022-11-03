using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using Domain.Features.Moves.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Features.Moves.Commands.CreateMove
{
    public class CreateMoveCommand : IRequest<CreatedMoveDto>// , ISecuredRequest
    {
        public CreatedMoveDto createdMoveDto { get; set; }

        //public string[] Roles => new[] { "admin" };

        public class CreateMoveCommandHandler : IRequestHandler<CreateMoveCommand, CreatedMoveDto>
        {
            IMoveRepository _moveRepository;
            IMapper _mapper;

            public CreateMoveCommandHandler(IMoveRepository moveRepository, IMapper mapper)
            {
                _moveRepository = moveRepository;
                _mapper = mapper;
            }

            public async Task<CreatedMoveDto> Handle(CreateMoveCommand request, CancellationToken cancellationToken)
            {
                Move mappedMove = _mapper.Map<Move>(request.createdMoveDto);
                Move addedMove = await _moveRepository.AddAsync(mappedMove);
                CreatedMoveDto result = _mapper.Map<CreatedMoveDto>(addedMove);
                return result;
            }
        }
    }
}
