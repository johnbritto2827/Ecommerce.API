using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models.Input.Vendor;
using ECommerce.Services.Vendor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers.Vendor
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorDetailsController : ControllerBase
    {
        private readonly IVendorDetailsService _VendorDetailsService;
        public VendorDetailsController(IVendorDetailsService VendorDetailsService)
        {
            _VendorDetailsService = VendorDetailsService;
        }


        [HttpGet]
        [ActionName("GetVendor")]
        [Route("GetVendor")]
        public async Task<IActionResult> GetVendor()
        {
            return Ok(await _VendorDetailsService.GetVendor());
        }

        [HttpPost]
        [ActionName("SaveVendor")]
        [Route("SaveVendor")]
        public async Task<IActionResult> SaveVendor(VendorDetails Vendor)
        {

            return Ok(await _VendorDetailsService.SaveVendor(Vendor));
        }

        [HttpDelete]
        [ActionName("VendorDelete")]
        [Route("VendorDelete")]
        public async Task<IActionResult> DeleteVendor(int VendorId)
        {
            return Ok(await _VendorDetailsService.DeleteVendor(VendorId));
        }
    }
}
