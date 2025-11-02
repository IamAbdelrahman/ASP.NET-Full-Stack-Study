 using Demos.DTO;
using Demos.Models;
using Demos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Retrieves all products from the data source.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return Ok(products);
        }

        /// <summary>
        /// Creates a new product in the data source.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }
            var productEntity = new Product
            {
                Name = product.Name,
                Price = product.Price
            };
            await _unitOfWork.Products.AddAsync(productEntity);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetAll), product);
        }
    }
}
