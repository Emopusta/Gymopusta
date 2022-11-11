using Application.Features.Moves.Dtos;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Moves.Commands.DeleteMove
{
    public class DeleteMoveCommand : IRequest<DeletedMoveDto>
    {
        public int Id { get; set; }

        public class DeleteMoveCommandHandler : IRequestHandler<DeleteMoveCommand, DeletedMoveDto>
        {
            private readonly IMoveRepository _moveRepository;

            public DeleteMoveCommandHandler(IMoveRepository moveRepository)
            {
                _moveRepository = moveRepository;
            }

            public async Task<DeletedMoveDto> Handle(DeleteMoveCommand request, CancellationToken cancellationToken)
            {
                Move? moveToDelete = await _moveRepository.GetAsync(m => m.Id == request.Id);

                if(moveToDelete == null) { throw new BusinessException("move must exist."); }

                Move deletedMove = await _moveRepository.DeleteAsync(moveToDelete);

                DeletedMoveDto result = new()
                {
                    Id = deletedMove.Id,
                    MoveName = deletedMove.MoveName
                };
                return result;

            }
        }
    }
}
