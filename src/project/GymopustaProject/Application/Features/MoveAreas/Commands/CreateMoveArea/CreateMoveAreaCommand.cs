using Application.Features.MoveAreas.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoveAreas.Commands.CreateMoveArea
{
    public class CreateMoveAreaCommand : IRequest<CreatedMoveAreaDto>
    {
        public string MoveAreaName { get; set; }

        public class CreateMoveAreaCommandHandler : IRequestHandler<CreateMoveAreaCommand, CreatedMoveAreaDto>
        {
            private readonly IMoveAreaRepository _moveAreaRepository;
            private readonly IMapper _mapper;

            public CreateMoveAreaCommandHandler(IMoveAreaRepository moveAreaRepository, IMapper mapper)
            {
                _moveAreaRepository = moveAreaRepository;
                _mapper = mapper;
            }

            public async Task<CreatedMoveAreaDto> Handle(CreateMoveAreaCommand request, CancellationToken cancellationToken)
            {
                MoveArea mappedMoveArea = _mapper.Map<MoveArea>(request);
                MoveArea createdMoveArea = await _moveAreaRepository.AddAsync(mappedMoveArea);
                CreatedMoveAreaDto mappedResult = _mapper.Map<CreatedMoveAreaDto>(createdMoveArea);
                return mappedResult;
            }
        }
    }
}
