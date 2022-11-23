using Application.Features.GymProgramItems.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GymProgramItems.Commands.AddGymProgramItem
{
    public class AddGymProgramItemCommand : IRequest<AddedGymProgramItemDto>
    {
        public int GymProgramId { get; set; }
        public int MoveId { get; set; }
        public string Reps { get; set; }
        public string Sets { get; set; }
        public string RestTime { get; set; }

        public class AddGymProgramItemCommandHandler : IRequestHandler<AddGymProgramItemCommand, AddedGymProgramItemDto>
        {
            private readonly IGymProgramItemRepository _gymProgramItemRepository;

            public AddGymProgramItemCommandHandler(IGymProgramItemRepository gymProgramItemRepository)
            {
                _gymProgramItemRepository = gymProgramItemRepository;
            }

            public async Task<AddedGymProgramItemDto> Handle(AddGymProgramItemCommand request, CancellationToken cancellationToken)
            {
                GymProgramItem gymProgramItemToAdd = new()
                {
                    GymProgramId = request.GymProgramId,
                    MoveId = request.MoveId,
                    Reps = request.Reps,
                    Sets = request.Sets,
                    RestTime = request.RestTime
                };

                GymProgramItem addedGymProgramItem = await _gymProgramItemRepository.AddAsync(gymProgramItemToAdd);

                AddedGymProgramItemDto result = new()
                {
                    Id = addedGymProgramItem.Id,
                    GymProgramId = addedGymProgramItem.GymProgramId,
                    MoveId = addedGymProgramItem.MoveId,
                    Reps = addedGymProgramItem.Reps,
                    Sets = addedGymProgramItem.Sets,
                    RestTime = addedGymProgramItem.RestTime
                };
                return result;
            }
        }
    }
}
