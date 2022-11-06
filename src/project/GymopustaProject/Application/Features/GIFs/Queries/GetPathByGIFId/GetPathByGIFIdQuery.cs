using Application.Features.GIFs.Constants;
using Application.Features.GIFs.Dtos;
using Application.Features.GIFs.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GIFs.Queries.GetPathByGIFId
{
    public class GetPathByGIFIdQuery : IRequest<GIFListDto>
    {
        public int Id { get; set; }

        public class GetPathByGIFIdQueryHandler : IRequestHandler<GetPathByGIFIdQuery, GIFListDto>
        {
            private readonly IGIFRepository _gIFRepository;

            public GetPathByGIFIdQueryHandler(IGIFRepository gIFRepository)
            {
                _gIFRepository = gIFRepository;
            }

            public async Task<GIFListDto> Handle(GetPathByGIFIdQuery request, CancellationToken cancellationToken)
            {
                GIF? gif = await _gIFRepository.GetAsync(g => g.Id == request.Id);
                GIFListDto result = new()
                {
                    Id = gif.Id,
                    GIFPath = PathConstants.GlobalGIFPath + gif.GIFPath
                };
                
                return result;

            }
        }
    }
}
