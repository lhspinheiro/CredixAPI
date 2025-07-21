using CredixAPI.Application.UseCases.Register;
using CredixAPI.Communication.Request;
using CredixAPI.Communication.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CredixAPI.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessages), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromServices] IRegisterUseCase useCase, [FromBody] RequestLoansJson request)
        {
            var response = await useCase.Execute(request);
            
            return Ok(response);
        }
    }
}
