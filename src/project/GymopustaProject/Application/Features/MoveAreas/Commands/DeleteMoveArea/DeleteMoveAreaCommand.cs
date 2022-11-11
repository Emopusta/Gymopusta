using Application.Features.MoveAreas.Dtos;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoveAreas.Commands.DeleteMoveArea
{
    public class DeleteMoveAreaCommand : IRequest<DeletedMoveAreaDto>
    {
        public int Id { get; set; }

        public class DeleteMoveAreaCommandHandler : IRequestHandler<DeleteMoveAreaCommand, DeletedMoveAreaDto>
        {
            private readonly IMoveAreaRepository _moveAreaRepository;

            public DeleteMoveAreaCommandHandler(IMoveAreaRepository moveAreaRepository)
            {
                _moveAreaRepository = moveAreaRepository;
            }

            public async Task<DeletedMoveAreaDto> Handle(DeleteMoveAreaCommand request, CancellationToken cancellationToken)
            {
                MoveArea? moveAreaToDelete = await _moveAreaRepository.GetAsync(m => m.Id == request.Id);

                if (moveAreaToDelete == null) { throw new BusinessException("moveArea must exist"); }

                MoveArea deletedMoveArea = await _moveAreaRepository.DeleteAsync(moveAreaToDelete);

                DeletedMoveAreaDto result = new()
                {
                    Id = deletedMoveArea.Id,
                    MoveAreaName = deletedMoveArea.MoveAreaName
                };
                return result;
            }
        }
    }
}
