using Application.Features.Descriptions.Dtos;
using Application.Features.Descriptions.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Descriptions.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<Description>, DescriptionListModel>().ReverseMap();
            CreateMap<Description, DescriptionListDto>().ReverseMap();
        }
    }
}
