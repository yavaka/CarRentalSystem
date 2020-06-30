using System.Threading.Tasks;
using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Application.Features.Identity;
using CarRentalSystem.Application.Features.Identity.Commands;
using CarRentalSystem.Web.Common;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalSystem.Web.Features
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ApiController
    {
        private readonly IIdentity identity;

        public IdentityController(IIdentity identity) => this.identity = identity;

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(UserInputModel model)
        {
            var result = await this.identity.Register(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
        {
            return await this.Mediator.Send(command).ToActionResult();
        }
    }
}
