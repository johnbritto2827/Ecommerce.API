using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Repository
{
    using Dapper;
    using ECommerce.Common;
    using ECommerce.DBEngine;
    using ECommerce.Models.Input;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProductDetailsRepository
    {
        Task<List<ProductDetails>> GetProduct();
        Task<int> SaveProduct(ProductDetails Product);
        Task DeleteProduct(int ProductId);
        Task<ProductDetails> EditProductById(int ProductId);

    }
    public class ProductDetailsRepository : IProductDetailsRepository
    {
        private readonly ISQLServerHandler _SQLServerHandler;

        public ProductDetailsRepository(ISQLServerHandler sQLServerHandler)
        {
            _SQLServerHandler = sQLServerHandler;
        }

        public async Task<List<ProductDetails>> GetProduct()
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@ActionId", 2, DbType.Int32, ParameterDirection.Input);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.SendErrorToText(ex);
            }
            return (await _SQLServerHandler.QueryAsync<ProductDetails>(_SQLServerHandler.Connection, StroredProc.ProductDetails, CommandType.StoredProcedure, parameters)).ToList();
        }

        public async Task<int> SaveProduct(ProductDetails Product)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@ActionId", 1, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@ProductId", Product.ProductId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@VendorId", Product.VendorId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@CategoryId", Product.CategoryId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@ProductName", Product.ProductName, DbType.String, ParameterDirection.Input);
                parameters.Add("@ProductImage", Product.ProductImage, DbType.String, ParameterDirection.Input);
                parameters.Add("@Description", Product.Description, DbType.String, ParameterDirection.Input);
                parameters.Add("@Specification", Product.Specification, DbType.String, ParameterDirection.Input);
                parameters.Add("@Price", Product.Price, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@Discount", Product.Discount, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@ShippingCharge", Product.ShippingCharge, DbType.String, ParameterDirection.Input);
                parameters.Add("@returnVal", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _SQLServerHandler.ExecuteAsync(_SQLServerHandler.Connection, StroredProc.ProductDetails, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.SendErrorToText(ex);
            }

            return parameters.Get<int>("@returnVal");

        }
        public async Task<ProductDetails> EditProductById(int ProductId)        {            var parameters = new DynamicParameters();            parameters.Add("@ActionId", 1, DbType.Int32, ParameterDirection.Input);            parameters.Add("@ProductId", ProductId, DbType.Int32, ParameterDirection.Input);            return await _SQLServerHandler.QueryFirstOrDefaultAsync<ProductDetails>(_SQLServerHandler.Connection, StroredProc.ProductDetails, CommandType.StoredProcedure, parameters);        }

        public async Task DeleteProduct(int ProductId)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@ActionId", 3, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@ProductId", ProductId, DbType.Int32, ParameterDirection.Input);
                await _SQLServerHandler.ExecuteAsync(_SQLServerHandler.Connection, StroredProc.ProductDetails, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.SendErrorToText(ex);
            }
        }

    }
}
