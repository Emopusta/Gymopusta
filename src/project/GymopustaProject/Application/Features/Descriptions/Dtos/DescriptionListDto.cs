using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Descriptions.Dtos
{
    public class DescriptionListDto
    {
        public int Id { get; set; }
        public int MoveId { get; set; }
        public string DescriptionText { get; set; }
    }
}
