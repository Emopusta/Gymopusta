using Application.Features.Descriptions.Models;
using Application.Features.GIFs.Constants;
using Application.Features.GIFs.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.MoveService
{
    public class MoveManager : IMoveService
    {
        private readonly IDescriptionRepository _descriptionRepository;
        private readonly IGIFRepository _gIFRepository;
        private readonly IMapper _mapper;

        public MoveManager(IDescriptionRepository descriptionRepository, IGIFRepository gIFRepository, IMapper mapper)
        {
            _descriptionRepository = descriptionRepository;
            _gIFRepository = gIFRepository;
            _mapper = mapper;
        }

        public async Task<DescriptionListModel> GetDescriptionsByMoveId(int id)
        {
            IPaginate<Description>? descriptions = await _descriptionRepository.GetListAsync(p=> p.MoveId == id, index:0, size:10);

            DescriptionListModel result = _mapper.Map<DescriptionListModel>(descriptions);
            return result;
        }

        public async Task<GIFListDto> GetManualMoveGIFByMoveId(int id)
        {
            GIF? gif = await _gIFRepository.GetAsync(g => g.MoveId == id);

            if (gif == null) {
                GIFListDto nResult = new()
                {
                    Id = id,
                    GIFPath = PathConstants.HttpServerPath + "defaultGIF.png"
                };
                return nResult;
                 }

            GIFListDto result = new()
            {
                Id = gif.Id,
                GIFPath = PathConstants.HttpServerPath + gif.GIFPath
            };
            return result;
        }
    }
}
