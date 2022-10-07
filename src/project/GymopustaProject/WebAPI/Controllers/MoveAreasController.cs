using Application.Features.MoveAreas.Commands.CreateMoveArea;
using Application.Features.MoveAreas.Dtos;
using KodlamaioDevs.WebAPI.Controllers;
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
    }
}
