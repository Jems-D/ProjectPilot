using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Features.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProjectsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProject([FromBody] CreateProjectCommand command)
        {
            var id = await _sender.Send(command);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(id);
        }
    }
}
