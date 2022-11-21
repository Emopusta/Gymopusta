using Application.Features.GIFs.Constants;
using Application.Features.GIFs.Dtos;
using Application.Services.Repositories;
using Core.Utilities.Helpers.FileHelper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GIFs.Commands.AddGIF
{
    public class AddGIFCommand : IRequest<AddedGIFDto>
    {
        public IFormFile File { get; set; }
        public int MoveId{ get; set; }

        public class AddGIFCommandHandler : IRequestHandler<AddGIFCommand, AddedGIFDto>
        {
            private readonly IGIFRepository _gifRepository;

            public AddGIFCommandHandler(IGIFRepository gifRepository)
            {
                _gifRepository = gifRepository;
            }

            public async Task<AddedGIFDto> Handle(AddGIFCommand request, CancellationToken cancellationToken)
            {
                GIF gif = new()
                {
                    MoveId = request.MoveId,
                    GIFPath = FileHelper.Upload(request.File, PathConstants.GIFsPath),
                    IsManual = false
                };
                GIF addedGIF = await _gifRepository.AddAsync(gif);
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
