using Application.Features.InstructorCustomers.Commands.AddInstructorCustomer;
using Application.Features.InstructorCustomers.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorCustomersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddInstructorCustomerCommand addInstructorCustomerCommand)
        {
            AddedInstructorCustomerDto result = await Mediator.Send(addInstructorCustomerCommand);
            return Ok(result);
        }

    }
}
