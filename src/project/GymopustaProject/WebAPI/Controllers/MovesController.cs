using Application.Features.Moves.Commands.UpdateMove;
using Application.Features.Moves.Dtos;
using Application.Features.Moves.Models;
using Application.Features.Moves.Queries.GetByMoveAreaIdMove;
using Application.Features.Moves.Queries.GetListMove;
using Core.Application.Requests;
using Domain.Features.Moves.Commands.CreateMove;
using Domain.Features.Moves.Dtos;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Moves.Commands.DeleteMove;
using Application.Features.Moves.Queries.GetMoveDetailsById;

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

        [HttpGet("getdetails")]
        public async Task<IActionResult> GetDetails([FromQuery] int id)
        {
            GetMoveDetailsByIdQuery getMoveDetailsByIdQuery = new() { Id = id };
            MoveDetailsDto result = await Mediator.Send(getMoveDetailsByIdQuery);
            return Ok(result);
        }

        [HttpGet("getbyareaid")]
        public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest, int moveAreaId)
        {
            GetByMoveAreaIdMoveQuery getByMoveAreaIdMoveQuery = new() { PageRequest = pageRequest, MoveAreaId = moveAreaId };
            MoveListModel result = await Mediator.Send(getByMoveAreaIdMoveQuery);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMoveCommand updateMoveCommand)
        {
            UpdatedMoveDto result = await Mediator.Send(updateMoveCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteMoveCommand deleteMoveCommand)
        {
            DeletedMoveDto result = await Mediator.Send(deleteMoveCommand);
            return Ok(result);
        }
    }
}
