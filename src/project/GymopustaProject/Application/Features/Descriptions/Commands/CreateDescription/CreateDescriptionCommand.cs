using Application.Features.Descriptions.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Descriptions.Commands.CreateDescription
{
    public class CreateDescriptionCommand : IRequest<CreatedDescriptionDto>
    {
        public int MoveId { get; set; }
        public string DescriptionText { get; set; }

        public class CreateDescriptionCommandHandler : IRequestHandler<CreateDescriptionCommand, CreatedDescriptionDto>
        {
            IDescriptionRepository _descriptionRepository;

            public CreateDescriptionCommandHandler(IDescriptionRepository descriptionRepository)
            {
                _descriptionRepository = descriptionRepository;
            }

            public async Task<CreatedDescriptionDto> Handle(CreateDescriptionCommand request, CancellationToken cancellationToken)
            {
                Description description = new Description();
                description.MoveId = request.MoveId;
                description.DescriptionText = request.DescriptionText;

                Description addedDescription = await _descriptionRepository.AddAsync(description);
                CreatedDescriptionDto result = new CreatedDescriptionDto()
                {
                    MoveId = addedDescription.MoveId,
                    DescriptionText = addedDescription.DescriptionText
                };
                return result;
            }
        }
    }
}
