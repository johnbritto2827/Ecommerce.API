
namespace ECommerce.API.Controllers
{

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ECommerce.Services;
    using ECommerce.Models.Input;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        [HttpGet]
        [ActionName("GetProduct")]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(await _ProductService.GetProduct());
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductAdd product)
        {

            return Ok(await _ProductService.SaveProduct(product));
        }
        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(int ProductId)
        {
            return Ok(await _ProductService.GetProductById(ProductId));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            return Ok(await _ProductService.DeleteProduct(ProductId));
        }

    }
}
