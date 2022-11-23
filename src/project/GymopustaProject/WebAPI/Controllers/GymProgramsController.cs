using Application.Features.GymPrograms.Commands.AddGymProgram;
using Application.Features.GymPrograms.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymProgramsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddGymProgramCommand addGymProgramCommand)
        {
            
            AddedGymProgramDto result = await Mediator.Send(addGymProgramCommand);
            return Ok(result);
        }

    }
}
