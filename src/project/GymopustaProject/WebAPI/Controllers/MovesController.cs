using Application.Features.Moves.Models;
using Application.Features.Moves.Queries.GetByMoveAreaIdMove;
using Application.Features.Moves.Queries.GetListMove;
using Core.Application.Requests;
using Domain.Features.Moves.Commands.CreateMove;
using Domain.Features.Moves.Dtos;
using KodlamaioDevs.WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateMoveCommand createMoveCommand)
        {
            CreatedMoveDto result = await Mediator.Send(createMoveCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
        {
            GetListMoveQuery getListMoveQuery = new() { PageRequest = pageRequest };
            MoveListModel result = await Mediator.Send(getListMoveQuery);
            return Ok(result);
        }

        [HttpGet("getbyareaid")]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest, int moveAreaId)
        {
            GetByMoveAreaIdMoveQuery getByMoveAreaIdMoveQuery = new() { PageRequest = pageRequest, MoveAreaId = moveAreaId };
            MoveListModel result = await Mediator.Send(getByMoveAreaIdMoveQuery);
            return Ok(result);
        }
    }
}
