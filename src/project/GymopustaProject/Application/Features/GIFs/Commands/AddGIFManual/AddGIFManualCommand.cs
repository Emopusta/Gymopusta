using Application.Features.GIFs.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GIFs.Commands.AddGIFManual
{
    public class AddGIFManualCommand : IRequest<AddedGIFDto>
    {
        public int MoveId { get; set; }
        public string Path { get; set; }
        public class AddGIFManualCommandHandler : IRequestHandler<AddGIFManualCommand, AddedGIFDto>
        {
            private readonly IGIFRepository _gIFRepository;

            public AddGIFManualCommandHandler(IGIFRepository gIFRepository)
            {
                _gIFRepository = gIFRepository;
            }

            public async Task<AddedGIFDto> Handle(AddGIFManualCommand request, CancellationToken cancellationToken)
            {
                GIF gifToAdd = new()
                {
                    MoveId = request.MoveId,
                    GIFPath = request.Path,
                    IsManual = true
                };

                GIF addedGIF = await _gIFRepository.AddAsync(gifToAdd);

                AddedGIFDto result = new()
                {
                    MoveId = addedGIF.MoveId,
                    GIFPath = addedGIF.GIFPath
                };
                return result;
            }
        }


    }
}
