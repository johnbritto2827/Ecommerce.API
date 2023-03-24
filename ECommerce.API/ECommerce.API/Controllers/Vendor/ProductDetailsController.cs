

namespace ECommerce.API.Controllers
{
    using System.Threading.Tasks;
    using ECommerce.Models.Input;
    using ECommerce.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsService _ProductDetailsService;
        public ProductDetailsController(IProductDetailsService ProductDetailsService)
        {
            _ProductDetailsService = ProductDetailsService;
        }


        [HttpGet]
        [ActionName("GetProduct")]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(await _ProductDetailsService.GetProduct());
        }

        [HttpPost]
        [ActionName("SaveProduct")]
        [Route("SaveProduct")]
        public async Task<IActionResult> SaveProduct(ProductDetails Product)
        {

            return Ok(await _ProductDetailsService.SaveProduct(Product));
        }
        [HttpGet("EditProductIdById/{ProductId}")]
        //[ActionName("GetCandidateById")]
        //[Route("EditCandidateById")]
        public async Task<IActionResult> EditProductIdById(int ProductId)        {            return Ok(await _ProductDetailsService.EditProductById(ProductId));        }
        [HttpDelete("ProductDelete/{ProductId}")]
        //[ActionName("ProductDelete")]
        //[Route("ProductDelete")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            return Ok(await _ProductDetailsService.DeleteProduct(ProductId));
        }

    }
}
