using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
    {
        public string Name { get; set; }

        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = new OperationClaim()
                {
                    Name = request.Name
                };

                OperationClaim addedOperationClaim = await _operationClaimRepository.AddAsync(operationClaim);

                CreatedOperationClaimDto result = new CreatedOperationClaimDto()
                {
                    Id = addedOperationClaim.Id,
                    Name = addedOperationClaim.Name
                };
                return result;
            }
        }
    }
}
