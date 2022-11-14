using Application.Features.GIFs.Constants;
using Application.Features.GIFs.Dtos;
using Application.Features.GIFs.Queries.GetPathByGIFId;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GIFs.Queries.GetGIFPathByMoveId
{
    public class GetGIFPathByMoveIdQuery
    {
        public int MoveId { get; set; }

        public class GetGIFPathByMoveIdQueryHandler : IRequestHandler<GetPathByGIFIdQuery, GIFListDto>
        {
            private readonly IGIFRepository _gIFRepository;

            public GetGIFPathByMoveIdQueryHandler(IGIFRepository gIFRepository)
            {
                _gIFRepository = gIFRepository;
            }

            public async Task<GIFListDto> Handle(GetPathByGIFIdQuery request, CancellationToken cancellationToken)
            {
                GIF? gif = await _gIFRepository.GetAsync(g => g.MoveId == request.Id);

                if (gif == null)
                {
                    GIFListDto exceptionResult = new()
                    {
                        Id = 0,
                        GIFPath = PathConstants.HttpServerPath + "defaultGIF.png"
                    };
                    return exceptionResult;
                };

                GIFListDto result = new()
                {
                    Id = gif.Id,
                    GIFPath = PathConstants.HttpServerPath + gif.GIFPath
                };

                return result;

            }
        }
    }
}
