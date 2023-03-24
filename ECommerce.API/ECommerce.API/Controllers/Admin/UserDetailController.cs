namespace ECommerce.API.Controllers
{
    using ECommerce.Models.Input;
    using ECommerce.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IUserDetailService _UserDetailService;
        public UserDetailController(IUserDetailService UserDetailService)
        {
            _UserDetailService = UserDetailService;
        }


        [HttpGet]
        [ActionName("GetUser")]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await _UserDetailService.GetUser());
        }

        [HttpPost]
        [ActionName("SaveUser")]
        [Route("SaveUser")]
        public async Task<IActionResult> SaveUser(UserDetail User)
        {

            return Ok(await _UserDetailService.SaveUser(User));
        }

        [HttpDelete]
        [ActionName("UserDelete")]
        [Route("UserDelete")]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            return Ok(await _UserDetailService.DeleteUser(UserId));
        }

    }
}
