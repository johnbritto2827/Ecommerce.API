
namespace ECommerce.Services
{
    using ECommerce.Models;
    using System;
    using System.Threading.Tasks;
    using ECommerce.Models.Input;
    using ECommerce.Repository;



    public interface IOrderService
    {
        Task<ResultArgs> GetOrder();
        Task<ResultArgs> SaveOrder(Order Order);

    }
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            this._OrderRepository = OrderRepository;
        }


        public async Task<ResultArgs> GetOrder()
        {
            var RresultArgs = new ResultArgs();

            var OrderResult = await _OrderRepository.GetOrder();


            if (OrderResult != null)
            {
                RresultArgs.StatusCode = 200;
                RresultArgs.StatusMessage = "Record is success";
                RresultArgs.ResultData = OrderResult;
            }
            else
            {
                RresultArgs.StatusCode = 205;
                RresultArgs.StatusMessage = "Failed to save";
            }
            return RresultArgs;
        }
        public async Task<ResultArgs> SaveOrder(Order Order)
        {
            var RresultArgs = new ResultArgs();

            var OrderId = await _OrderRepository.SaveOrder(Order);
            if (OrderId > 0)
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
    }
}