using Application.Features.GIFs.Constants;
using Application.Features.GIFs.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GIFs.Queries.GetManualPathByMoveId
{
    public class GetManualPathByMoveIdQuery : IRequest<GIFListDto>
    {
        public int MoveId { get; set; }

        public class GetGIFPathByMoveIdQueryHandler : IRequestHandler<GetManualPathByMoveIdQuery, GIFListDto>
        {
            private readonly IGIFRepository _gIFRepository;

            public GetGIFPathByMoveIdQueryHandler(IGIFRepository gIFRepository)
            {
                _gIFRepository = gIFRepository;
            }

            public async Task<GIFListDto> Handle(GetManualPathByMoveIdQuery request, CancellationToken cancellationToken)
            {
                GIF? gif = await _gIFRepository.GetAsync(g => g.MoveId == request.MoveId);

                if (!gif.IsManual)
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
                    GIFPath = gif.GIFPath
                };

                return result;

            }
        }
    }
}
