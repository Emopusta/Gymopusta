using Application.Features.GIFs.Commands.AddGIF;
using Application.Features.GIFs.Commands.DeleteGIF;
using Application.Features.GIFs.Dtos;
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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetPathByGIFIdQuery getPathByGIFIdQuery)
        {
            GIFListDto result = await Mediator.Send(getPathByGIFIdQuery);
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
