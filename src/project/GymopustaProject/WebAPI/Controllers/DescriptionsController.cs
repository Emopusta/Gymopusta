using WebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.MoveAreas.Commands.CreateMoveArea;
using Application.Features.MoveAreas.Dtos;
using Application.Features.Descriptions.Commands.CreateDescription;
using Application.Features.Descriptions.Dtos;
using Core.Application.Requests;
using Application.Features.Descriptions.Queries.GetByMoveIdDescriptionQuery;
using Application.Features.Descriptions.Models;
using Application.Features.Descriptions.Commands.DeleteDescription;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDescriptionCommand createDescriptionCommand)
        {
            CreatedDescriptionDto result = await Mediator.Send(createDescriptionCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetByMoveId([FromQuery] PageRequest pageRequest, int moveId)
        {
            GetByMoveIdDescriptionQuery getByMoveIdDescriptionQuery = new() { PageRequest = pageRequest, MoveId = moveId };
            DescriptionListModel result = await Mediator.Send(getByMoveIdDescriptionQuery);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteDescriptionCommand deleteDescriptionCommand)
        {
            DeletedDescriptionDto result = await Mediator.Send(deleteDescriptionCommand);
            return Ok(result);
        }
    }
}
