using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjecTasksController : ControllerBase
    {
        private readonly ISender _sender;

        public ProjecTasksController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProjectTask(
            [FromBody] CreateProjectTaskCommand command
        )
        {
            var projectTaskId = await _sender.Send(command);
            if (projectTaskId is null)
            {
                return BadRequest("Project not found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return projectTaskId;
        }
    }
}
