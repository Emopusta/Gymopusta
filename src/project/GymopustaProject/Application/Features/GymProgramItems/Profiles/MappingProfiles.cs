using Application.Features.GymProgramItems.Dtos;
using Application.Features.GymProgramItems.Models;
using Application.Features.Moves.Dtos;
using Application.Features.Moves.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GymProgramItems.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<GymProgramItem>, GymProgramItemListModel>().ReverseMap();
            CreateMap<GymProgramItem, GymProgramItemListDto>().ReverseMap();
            
        }
    }
}
