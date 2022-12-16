using Application.Features.Moves.Dtos;
using Application.Features.Moves.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using Domain.Features.Moves.Commands.CreateMove;
using Domain.Features.Moves.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Moves.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Move, CreatedMoveDto>().ReverseMap();
            CreateMap<Move, CreateMoveCommand>().ReverseMap();

            CreateMap<IPaginate<Move>, MoveListModel>().ReverseMap();
            CreateMap<Move, MoveListDto>().ReverseMap();

            
            


        }
    }
}
