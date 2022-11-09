using Application.Features.OperationClaims.Dtos;
using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaim = new()
                {
                    OperationClaimId = request.OperationClaimId,
                    UserId = request.UserId
                };
                UserOperationClaim addedUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaim);
                CreatedUserOperationClaimDto result = new()
                {
                    OperationClaimId = addedUserOperationClaim.OperationClaimId,
                    UserId = addedUserOperationClaim.UserId
                };
                return result;
            }
        }
    }
}
