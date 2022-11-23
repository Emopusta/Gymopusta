using Application.Features.IndividualCustomers.Commands.AddIndividualCustomer;
using Application.Features.IndividualCustomers.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddIndividualCustomerCommand addIndividualCustomerCommand)
        {
            AddedIndividualCustomerDto result = await Mediator.Send(addIndividualCustomerCommand);
            return Ok(result);
        }

    }
}
