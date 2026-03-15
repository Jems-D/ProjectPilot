using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using backend.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ISender _sender;

        public AccountController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> RegisterAccount(
            [FromBody] CreateAccountCommand command
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdAcc = await _sender.Send(command);
            return createdAcc;
        }
    }
}
