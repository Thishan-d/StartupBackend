using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StartupCompanyApplication.Commands;
using StartupCompanyApplication.Queries;
using System.Threading.Tasks;

namespace StartupCompanyInfrastructure.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class StartupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StartupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStartups()
        {
            var query = new GetAllStartupsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{startupCompanyId}")]
        public async Task<IActionResult> GetStartupById(int startupCompanyId)
        {
            var query = new GetStartupByidQuery { StartupCompanyId = startupCompanyId };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                //var response = new { Message = "Startup found", Data = result };
                return NoContent();
            }
            else
            {
                return Ok(result);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateStartup(CreateStartupCommand command)
        {
            var result = await _mediator.Send(command);
            var response = new { Message = "Startup created", Data = result };
            return Created("{0}", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStartup(int id, UpdateStartupCommand command)
        {
            command.StartupCompanyId = id;
            var result = await _mediator.Send(command);
            return NoContent();
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStartup(int id, [FromBody] JsonPatchDocument<UpdateStartupCommandPatch> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest("Invalid patch document");
            }

            var command = new UpdateStartupCommandPatch { StartupCompanyId = id };

            patchDocument.ApplyTo(command);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStartup(int id)
        {

            var command = new DeleteStartupCommand { StartupCompanyId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }

}
