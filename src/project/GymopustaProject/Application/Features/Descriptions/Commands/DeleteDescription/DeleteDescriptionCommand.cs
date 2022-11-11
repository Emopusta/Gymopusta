using Application.Features.Descriptions.Dtos;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Descriptions.Commands.DeleteDescription
{
    public class DeleteDescriptionCommand : IRequest<DeletedDescriptionDto>
    {
        public int Id { get; set; }

        public class DeleteDescriptionCommandHandler : IRequestHandler<DeleteDescriptionCommand, DeletedDescriptionDto>
        {
            private readonly IDescriptionRepository _descriptionRepository;
            public async Task<DeletedDescriptionDto> Handle(DeleteDescriptionCommand request, CancellationToken cancellationToken)
            {
                Description? descriptionToDelete = await _descriptionRepository.GetAsync(d => d.Id == request.Id);

                if (descriptionToDelete != null) { throw new BusinessException("description does not exist"); }

                Description deletedDescription = await _descriptionRepository.DeleteAsync(descriptionToDelete);
                DeletedDescriptionDto result = new()
                {
                    Id = deletedDescription.Id,
                    DescriptionText = deletedDescription.DescriptionText,
                    MoveId = deletedDescription.MoveId,
                };
                return result;

            }
        }
    }
}
