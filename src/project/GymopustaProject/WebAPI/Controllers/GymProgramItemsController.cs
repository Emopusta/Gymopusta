using Application.Features.GymProgramItems.Commands.AddGymProgramItem;
using Application.Features.GymProgramItems.Dtos;
using Application.Features.GymProgramItems.Models;
using Application.Features.GymProgramItems.Queries.GetByGymProgramIdGymProgramItem;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymProgramItemsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddGymProgramItemCommand addGymProgramItemCommand)
        {
            AddedGymProgramItemDto result = await Mediator.Send(addGymProgramItemCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest, int gymProgramId)
        {
            GetByGymProgramIdGymProgramItemQuery getByGymProgramIdGymProgramItemQuery = new() { PageRequest = pageRequest, GymProgramId = gymProgramId };
            GymProgramItemListModel result = await Mediator.Send(getByGymProgramIdGymProgramItemQuery);
            return Ok(result);
        }


    }
}
