
namespace ECommerce.Services
{
    using ECommerce.Models;
    using System;
    using System.Threading.Tasks;
    using ECommerce.Models.Input;
    using ECommerce.Repository;


    public interface IProductService
    {
        Task<ResultArgs> GetProduct();
        Task<ResultArgs> SaveProduct(ProductAdd Product);
        Task<ResultArgs> GetProductById(int ProductId);
        Task<ResultArgs> DeleteProduct(int ProductId);
    }



    public class ProductService : IProductService
    {

        private readonly IProductRepository _ProductRepository;

        public ProductService(IProductRepository ProductRepository)
        {
            this._ProductRepository = ProductRepository;
        }


        public async Task<ResultArgs> GetProduct()
        {
            var RresultArgs = new ResultArgs();

            var ProductResult = await _ProductRepository.GetProduct();


            if (ProductResult != null)
            {
                RresultArgs.StatusCode = 200;
                RresultArgs.StatusMessage = "Record is success";
                RresultArgs.ResultData = ProductResult;
            }
            else
            {
                RresultArgs.StatusCode = 205;
                RresultArgs.StatusMessage = "Failed to save";
            }
            return RresultArgs;
        }
        public async Task<ResultArgs> SaveProduct(ProductAdd Product)
        {
            var RresultArgs = new ResultArgs();

            var ProductId = await _ProductRepository.SaveProduct(Product);
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
        public async Task<ResultArgs> GetProductById(int ProductId)
        {
            var RresultArgs = new ResultArgs();

            var ProductResult = await _ProductRepository.GetProductById(Convert.ToInt32(ProductId));

            RresultArgs.StatusCode = 200;
            RresultArgs.StatusMessage = "Get Product record is success";
            RresultArgs.ResultData = ProductResult;

            return RresultArgs;
        }
        public async Task<ResultArgs> DeleteProduct(int ProductId)
        {
            var RresultArgs = new ResultArgs();

            await _ProductRepository.DeleteProduct(ProductId);

            RresultArgs.StatusCode = 200;
            RresultArgs.StatusMessage = "Deleted success";

            return RresultArgs;
        }

    }
}