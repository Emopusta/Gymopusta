using Application.Features.MoveAreas.Commands.CreateMoveArea;
using Application.Features.MoveAreas.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MoveAreas.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MoveArea, CreateMoveAreaCommand>().ReverseMap();
            CreateMap<MoveArea, CreatedMoveAreaDto>().ReverseMap();
        }
    }
}
