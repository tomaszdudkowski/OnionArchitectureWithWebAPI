using Application.Features.ClientFeatures.Commands;
using Application.Features.ClientFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientController : BaseAPIController
    {
        /// <summary>
        /// Creates a New Client.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all Clients.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllClientsQuery()));
        }

        /// <summary>
        /// Gets Client Entity by ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetByID(int ID)
        {
            return Ok(await Mediator.Send(new GetClientByIdQuery { ID = ID }));
        }

        /// <summary>
        /// Deletes Clients Entity based on ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            return Ok(await Mediator.Send(new DeleteClientByIdCommand { ID = ID }));
        }

        /// <summary>
        /// Updates the Client Entity based on ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<IActionResult> Update(int ID, UpdateClientCommand command)
        {
            if(ID != command.ID)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
