

namespace ECommerce.Services
{
    using ECommerce.Models;
    using ECommerce.Models.Input;
    using ECommerce.Repository;
    using System;
    using System.Threading.Tasks;

    public interface IProductDetailsService
    {
        Task<ResultArgs> GetProduct();
        Task<ResultArgs> GetDistricts();
        Task<ResultArgs> SaveProduct(ProductDetails Product);
        Task<ResultArgs> DeleteProduct(int ProductId);
        Task<ResultArgs> EditProductById(int ProductId);


    }
    public class ProductDetailsService : IProductDetailsService
    {
        private readonly IProductDetailsRepository _ProductDetailsRepository;

        public ProductDetailsService(IProductDetailsRepository ProductDetailsRepository)
        {
            this._ProductDetailsRepository = ProductDetailsRepository;
        }
        public async Task<ResultArgs> GetProduct()
        {
            var RresultArgs = new ResultArgs();

            var ProductDetailsResult = await _ProductDetailsRepository.GetProduct();

            if (ProductDetailsResult != null)
            {
                RresultArgs.StatusCode = 200;
                RresultArgs.StatusMessage = "Record is success";
                RresultArgs.ResultData = ProductDetailsResult;
            }
            else
            {
                RresultArgs.StatusCode = 205;
                RresultArgs.StatusMessage = "Failed to save";
            }
            return RresultArgs;
        }

        public async Task<ResultArgs> SaveProduct(ProductDetails Product)
        {
            var RresultArgs = new ResultArgs();

            var ProductId = await _ProductDetailsRepository.SaveProduct(Product);
            if (ProductId > 0)
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
      
        public async Task<ResultArgs> DeleteProduct(int ProductId)
        {
            var RresultArgs = new ResultArgs();

            await _ProductDetailsRepository.DeleteProduct(ProductId);

            RresultArgs.StatusCode = 200;
            RresultArgs.StatusMessage = "Deleted success";

            return RresultArgs;
        }
        public async Task<ResultArgs> EditProductById(int ProductId)
        {
            var RresultArgs = new ResultArgs();

            await _ProductDetailsRepository.EditProductById(ProductId);

            RresultArgs.StatusCode = 200;
            RresultArgs.StatusMessage = "Edited success";

            return RresultArgs;
        }
        public async Task<ResultArgs> GetDistricts()
        {
            var RresultArgs = new ResultArgs();

            var ProductDetailsResult = await _ProductDetailsRepository.GetProduct();

            if (ProductDetailsResult != null)
            {
                RresultArgs.StatusCode = 200;
                RresultArgs.StatusMessage = "Record is success";
                RresultArgs.ResultData = ProductDetailsResult;
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
