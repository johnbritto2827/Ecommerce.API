using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Repository
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using ECommerce.DBEngine;
    using ECommerce.Common;
    using ECommerce.Models.Input;
    using ECommerce.Models.Output;
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrder();
        Task<int> SaveOrder(Order Order);
        //Task<ProductAdd> GetProductById(int ProductId);
        //Task DeleteProduct(int ProductId);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly ISQLServerHandler _SQLServerHandler;

        public OrderRepository(ISQLServerHandler sQLServerHandler)
        {
            _SQLServerHandler = sQLServerHandler;
        }

        public async Task<List<Order>> GetOrder()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ActionId",1, DbType.Int32, ParameterDirection.Input);
            return (await _SQLServerHandler.QueryAsync<Order>(_SQLServerHandler.Connection, StroredProc.GetOrder, CommandType.StoredProcedure, parameters)).ToList();
        }
        public async Task<int> SaveOrder(Order Order)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ActionId",2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@OrderId", Order.OrderId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@FullName", Order.FullName, DbType.String, ParameterDirection.Input);
            parameters.Add("@MobileNumber", Order.MobileNumber, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Address", Order.Address, DbType.String, ParameterDirection.Input);
            parameters.Add("@City", Order.City, DbType.String, ParameterDirection.Input);
            parameters.Add("@State", Order.State, DbType.String, ParameterDirection.Input);
            parameters.Add("@PinCode", Order.PinCode, DbType.Int64, ParameterDirection.Input);
            parameters.Add("@Email", Order.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("@AddressType", Order.AddressType, DbType.String, ParameterDirection.Input);
         //   parameters.Add("@Status", Order.Status, DbType.Int16, ParameterDirection.Input);
            parameters.Add("@returnVal", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _SQLServerHandler.ExecuteAsync(_SQLServerHandler.Connection, StroredProc.GetOrder, CommandType.StoredProcedure, parameters);
            return parameters.Get<int>("@returnVal");
        }
    }
    }
//OrderId, FullName, MobileNumber, Address, City, State, PinCode, Email, AddressType, Status, UserId, ProductId