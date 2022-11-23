using Application.Features.GymProgramItems.Commands.AddGymProgramItem;
using Application.Features.GymProgramItems.Dtos;
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

    }
}
