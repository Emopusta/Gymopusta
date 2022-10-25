using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Moves.Rules
{
    public class MoveBusinessRules
    {
        private readonly IMoveRepository _moveRepository;

        public MoveBusinessRules(IMoveRepository moveRepository)
        {
            this._moveRepository = moveRepository;
        }

        public async Task MoveMustExistWhenRequestedForUpdate(Move move)
        {
            if (move == null) throw new BusinessException("This move doesn't exist");
        }


    }
}
