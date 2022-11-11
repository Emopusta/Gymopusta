using Application.Features.GIFs.Dtos;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GIFs.Commands.DeleteGIF
{
    public class DeleteGIFCommand : IRequest<DeletedGIFDto>
    {
        public int Id { get; set; }

        public class DeleteGIFCommandHandler : IRequestHandler<DeleteGIFCommand, DeletedGIFDto>
        {
            private readonly IGIFRepository _gifRepository;

            public DeleteGIFCommandHandler(IGIFRepository gifRepository)
            {
                _gifRepository = gifRepository;
            }

            public async Task<DeletedGIFDto> Handle(DeleteGIFCommand request, CancellationToken cancellationToken)
            {
                GIF? gifToDelete = await _gifRepository.GetAsync(g => g.Id == request.Id);

                if(gifToDelete == null) { throw new BusinessException("gif must exist"); }

                GIF deletedGIF = await _gifRepository.DeleteAsync(gifToDelete);

                DeletedGIFDto result = new()
                {
                    Id = deletedGIF.Id,
                    GIFPath = deletedGIF.GIFPath
                };
                return result;

            }
        }
    }
}
