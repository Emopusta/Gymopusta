using Application.Features.GIFs.Commands.AddGIF;
using Application.Features.GIFs.Commands.Dtos;
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
    }
}
