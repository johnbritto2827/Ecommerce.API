

//namespace ECommerce.API.Controllers
//{
//    using System.Threading.Tasks;
//    using Microsoft.AspNetCore.Mvc;
//    using ECommerce.Services;
//    using ECommerce.Models.Input;

//    [Route("api/[controller]")] 
//    [ApiController]
//    public class OrderController : ControllerBase
//    {
//        private readonly IOrderService _OrderService;
//        public OrderController(IOrderService OrderService)
//        {
//           _OrderService = OrderService;
//        }

//       // GET: api/Order
//       [HttpGet]
//        public async Task<IActionResult> GetOrder()
//        {
//            return Ok(await _OrderService.GetOrder());
//        }
//        [HttpPost]
//        public async Task<IActionResult> SaveOrder(Order Order)
//        {

//            return Ok(await _OrderService.SaveOrder(Order));
//        }
//    }
//}
