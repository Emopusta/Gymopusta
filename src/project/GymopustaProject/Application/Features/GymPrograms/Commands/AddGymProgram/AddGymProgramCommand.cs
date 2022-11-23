using Application.Features.GymPrograms.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GymPrograms.Commands.AddGymProgram
{
    public class AddGymProgramCommand : IRequest<AddedGymProgramDto>
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public class AddGymProgramCommandHandler : IRequestHandler<AddGymProgramCommand, AddedGymProgramDto>
        {
            private readonly IGymProgramRepository _gymProgramRepository;

            public AddGymProgramCommandHandler(IGymProgramRepository gymProgramRepository)
            {
                _gymProgramRepository = gymProgramRepository;
            }

            public async Task<AddedGymProgramDto> Handle(AddGymProgramCommand request, CancellationToken cancellationToken)
            {
                GymProgram gymProgramToAdd = new()
                {
                    Name = request.Name,
                    UserId = request.UserId,
                };
                GymProgram addedGymProgram = await _gymProgramRepository.AddAsync(gymProgramToAdd);

                AddedGymProgramDto result = new()
                {
                    Id = addedGymProgram.Id, 
                    Name = addedGymProgram.Name,
                    UserId = addedGymProgram.UserId
                };
                return result;

            }
        }
    }
}
