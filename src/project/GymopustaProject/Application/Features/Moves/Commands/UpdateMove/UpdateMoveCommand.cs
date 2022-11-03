using Application.Features.Moves.Dtos;
using Application.Features.Moves.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Moves.Commands.UpdateMove
{
    public class UpdateMoveCommand : IRequest<UpdatedMoveDto>
    {
        public int Id { get; set; }
        public UpdatedMoveDto UpdatedMoveDto { get; set; }

        public class UpdateMoveCommandHandler : IRequestHandler<UpdateMoveCommand, UpdatedMoveDto>
        {
            private readonly IMoveRepository _moveRepository;
            private readonly MoveBusinessRules _moveBusinessRules;

            public UpdateMoveCommandHandler(IMoveRepository moveRepository, MoveBusinessRules moveBusinessRules)
            {
                _moveRepository = moveRepository;
                _moveBusinessRules = moveBusinessRules;
            }

            public async Task<UpdatedMoveDto> Handle(UpdateMoveCommand request, CancellationToken cancellationToken)
            {
                Move? moveToUpdate = await _moveRepository.GetAsync(m => m.Id == request.Id);

                await _moveBusinessRules.MoveMustExistWhenRequestedForUpdate(moveToUpdate);

                moveToUpdate.MoveName = request.UpdatedMoveDto.MoveName;
                moveToUpdate.MoveAreaId = request.UpdatedMoveDto.MoveAreaId;
                
                   
                

                Move updatedMove = await _moveRepository.UpdateAsync(moveToUpdate);


                UpdatedMoveDto updatedMoveDto = new()
                {
                    MoveAreaId = updatedMove.MoveAreaId,
                    MoveName = updatedMove.MoveName,
                };

                return updatedMoveDto;



            }
        }
    }
}
