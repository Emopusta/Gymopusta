using Application.Features.MoveAreas.Commands.CreateMoveArea;
using Application.Features.MoveAreas.Dtos;
using Application.Features.MoveAreas.Models;
using Application.Features.MoveAreas.Queries.GetListMoveArea;
using Core.Application.Requests;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveAreasController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateMoveAreaCommand createMoveAreaCommand)
        {
            CreatedMoveAreaDto result = await Mediator.Send(createMoveAreaCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            GetListMoveAreaQuery getListMoveAreaQuery = new() { PageRequest = pageRequest };
            MoveAreaListModel result = await Mediator.Send(getListMoveAreaQuery);
            return Ok(result);
        }

    }
}
