using Lista_Price.Data.Repository;
using Lista_Price.Entities;
using Lista_Price.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lista_Price.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_productRepository.GetAll());

        }
    
        [HttpGet("{id}")]
        public ActionResult Get(int id) 
        {
            return Ok(_productRepository.GetById(id));
        }

        [HttpPost]

        public ActionResult AddProduct([FromBody] ProductsForCreationRequest productdto)
        {
            Product product = new Product()
            {
                Name = productdto.Name,
                Description = productdto.Description,
                Price = productdto.Price,
            };
            return Ok(_productRepository.Create(product));
        }


        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] ProductsForCreationRequest productsForCreationRequestDto)
        {
            var productToModify = _productRepository.GetById(id);
            if (productToModify == null)
            {
                return NotFound($"No se encontró el producto con id {id}");
            }

            // Mapear DTO a entidad existente
            productToModify.Name = productsForCreationRequestDto.Name;
            productToModify.Description = productsForCreationRequestDto.Description;
            productToModify.Price = productsForCreationRequestDto.Price;
            productToModify.UpdatedAt = DateTime.Now;

            _productRepository.Update(productToModify);

            return NoContent();
        }
        [HttpPatch("restore/{id}")]
        public IActionResult Restore([FromRoute] int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return NotFound($"No se encontró el producto con id {id}");

            var restored = _productRepository.Restore(id);
            if (!restored)
                return StatusCode(500, "Error al restaurar el producto");

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return NotFound($"No se encontró el producto con id {id}");

            var deleted = _productRepository.Delete(product);

            if (!deleted)
                return StatusCode(500, "Error al eliminar el producto");

            return NoContent();
        }



    }
}
