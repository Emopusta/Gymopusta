using Application.Features.GIFs.Commands.AddGIF;
using Application.Features.GIFs.Commands.AddGIFManual;
using Application.Features.GIFs.Commands.DeleteGIF;
using Application.Features.GIFs.Dtos;
using Application.Features.GIFs.Queries.GetGIFPathByMoveId;
using Application.Features.GIFs.Queries.GetManualPathByMoveId;
using Application.Features.GIFs.Queries.GetPathByGIFId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GIFsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(IFormFile file,[FromForm] int moveId)
        {
            AddGIFCommand addGIFCommand = new() { File = file, MoveId = moveId };
            AddedGIFDto result = await Mediator.Send(addGIFCommand);
            return Ok(result);
        }
        [HttpPost("addManual")]
        public async Task<IActionResult> AddGIFManual([FromQuery] AddGIFManualCommand addGIFManualCommand)
        {
            AddedGIFDto result = await Mediator.Send(addGIFManualCommand);
            return Ok(result);
        }

        [HttpGet("getManual")]
        public async Task<IActionResult> Get([FromQuery] GetManualPathByMoveIdQuery getManualPathByMoveIdQuery)
        {
            GIFListDto result = await Mediator.Send(getManualPathByMoveIdQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetGIFPathByMoveIdQuery getGIFPathByMoveIdQuery)
        {
            GIFListDto result = await Mediator.Send(getGIFPathByMoveIdQuery);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGIFCommand deleteGIFCommand)
        {
            DeletedGIFDto result = await Mediator.Send(deleteGIFCommand);
            return Ok(result);
        }
    }
}
