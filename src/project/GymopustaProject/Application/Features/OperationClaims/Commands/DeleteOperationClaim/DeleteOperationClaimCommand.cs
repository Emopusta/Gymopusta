using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository)
            {
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim? operationClaimToDelete = await _operationClaimRepository.GetAsync(oc => oc.Id == request.Id);

                if (operationClaimToDelete == null) { throw new BusinessException("operationClaim must exist."); }

                OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaimToDelete);

                DeletedOperationClaimDto result = new()
                {
                    Id = deletedOperationClaim.Id,
                    Name = deletedOperationClaim.Name
                };
                return result;
            }
        }
    }
}
