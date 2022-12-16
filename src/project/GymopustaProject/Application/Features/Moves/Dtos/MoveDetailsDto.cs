using Application.Features.Descriptions.Models;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Moves.Dtos
{
    public class MoveDetailsDto
    {
        public int MoveId { get; set; }
        public string MoveName { get; set; }
        public string GIFPath { get; set; }
        public DescriptionListModel Descriptions { get; set; }
    }
}
