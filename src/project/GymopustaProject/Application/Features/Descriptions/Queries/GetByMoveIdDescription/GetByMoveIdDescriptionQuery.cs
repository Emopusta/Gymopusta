using Application.Features.Descriptions.Models;
using Application.Features.Moves.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Descriptions.Queries.GetByMoveIdDescriptionQuery
{
    public class GetByMoveIdDescriptionQuery :IRequest<DescriptionListModel>
    {
        public PageRequest PageRequest{ get; set; }
        public int MoveId { get; set; }

        public class GetByMoveIdDescriptionQueryHandler : IRequestHandler<GetByMoveIdDescriptionQuery, DescriptionListModel>
        {
            private readonly IDescriptionRepository _descriptionRepository;
            private readonly IMapper _mapper;

            public GetByMoveIdDescriptionQueryHandler(IDescriptionRepository descriptionRepository, IMapper mapper)
            {
                _descriptionRepository = descriptionRepository;
                _mapper = mapper;
            }

            public async Task<DescriptionListModel> Handle(GetByMoveIdDescriptionQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Description>? description = await _descriptionRepository.GetListAsync(d => d.MoveId == request.MoveId
               , index: request.PageRequest.Page
               , size: request.PageRequest.PageSize);

                DescriptionListModel mappedDescriptionListModel = _mapper.Map<DescriptionListModel>(description);
                return mappedDescriptionListModel;
            }
        }
    }
}
