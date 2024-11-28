using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.DAL.Entities;
using ProyectoFinal.Domain.Interfaces;

namespace ProyectoFinal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetBySupplier/{supplierId}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsBySupplierIdAsync(Guid supplierId)
        {
            var products = await _productService.GetProductsBySupplierIdAsync(supplierId);
            if (products == null || !products.Any()) return NotFound();
            return Ok(products);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Product>> CreateProductAsync(Product product)
        {
            try
            {
                var newProduct = await _productService.CreateProductAsync(product);
                if (newProduct == null) return NotFound();
                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", product.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Update")]
        [Route("Update")]
        public async Task<ActionResult<Product>> UpdateProductAsync(Product product)
        {
            try
            {
                var editedProduct = await _productService.UpdateProductAsync(product);
                if (editedProduct == null) return NotFound();
                return Ok(editedProduct);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", product.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<ActionResult<Product>> DeleteProductAsync(Guid id)
        {
            if (id == null) return BadRequest();
            var deletedProduct = await _productService.DeleteProductAsync(id);
            if (deletedProduct == null) return NotFound();
            return Ok(deletedProduct);
        }
    }
}
