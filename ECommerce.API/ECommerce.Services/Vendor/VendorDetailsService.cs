using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Services.Vendor
{
    using ECommerce.Models;
    using ECommerce.Models.Input;
    using ECommerce.Models.Input.Vendor;
    using ECommerce.Repository;
    using ECommerce.Repository.Vendor;
    using System;
    using System.Threading.Tasks;

    public interface IVendorDetailsService
    {
        Task<ResultArgs> GetVendor();
        Task<ResultArgs> GetDistricts();
        Task<ResultArgs> SaveVendor(VendorDetails Vendor);
        Task<ResultArgs> DeleteVendor(int VendorId);


    }
    public class VendorDetailsService : IVendorDetailsService
    {
        private readonly IVendorDetailsRepository _VendorDetailsRepository;

        public VendorDetailsService(IVendorDetailsRepository VendorDetailsRepository)
        {
            this._VendorDetailsRepository = VendorDetailsRepository;
        }
        public async Task<ResultArgs> GetVendor()
        {
            var RresultArgs = new ResultArgs();

            var VendorDetailsResult = await _VendorDetailsRepository.GetVendor();

            if (VendorDetailsResult != null)
            {
                RresultArgs.StatusCode = 200;
                RresultArgs.StatusMessage = "Record is success";
                RresultArgs.ResultData = VendorDetailsResult;
            }
            else
            {
                RresultArgs.StatusCode = 205;
                RresultArgs.StatusMessage = "Failed to save";
            }
            return RresultArgs;
        }

        public async Task<ResultArgs> SaveVendor(VendorDetails Vendor)
        {
            var RresultArgs = new ResultArgs();

            var VendorId = await _VendorDetailsRepository.SaveVendor(Vendor);
            if (VendorId > 0)
            {
                RresultArgs.StatusCode = 200;
                RresultArgs.StatusMessage = "Save success";
            }
            else
            {
                RresultArgs.StatusCode = 201;
                RresultArgs.StatusMessage = "Failed to save";
            }

            return RresultArgs;
        }

        public async Task<ResultArgs> DeleteVendor(int VendorId)
        {
            var RresultArgs = new ResultArgs();

            await _VendorDetailsRepository.DeleteVendor(VendorId);

            RresultArgs.StatusCode = 200;
            RresultArgs.StatusMessage = "Deleted success";

            return RresultArgs;
        }
        public async Task<ResultArgs> GetDistricts()
        {
            var RresultArgs = new ResultArgs();

            var VendorDetailsResult = await _VendorDetailsRepository.GetVendor();

            if (VendorDetailsResult != null)
            {
                RresultArgs.StatusCode = 200;
                RresultArgs.StatusMessage = "Record is success";
                RresultArgs.ResultData = VendorDetailsResult;
            }
            else
            {
                RresultArgs.StatusCode = 205;
                RresultArgs.StatusMessage = "Failed to save";
            }
            return RresultArgs;
        }
    }
}
