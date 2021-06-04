using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductController : BaseAPIController
    {
        /// <summary>
        /// Creates a New Product.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }

        /// <summary>
        /// Gets Product Entity by ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetByID(int ID)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { ID = ID }));
        }

        /// <summary>
        /// Deletes Product Entity based on ID. 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpDelete("{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { ID = ID }));
        }

        /// <summary>
        /// Updates the Product Entity based on ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<IActionResult> Update(int ID, UpdateProductCommand command)
        {
            if(ID != command.ID)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
