namespace ECommerce.Repository
{
    using Dapper;
    using ECommerce.Common;
    using ECommerce.DBEngine;
    using ECommerce.Models.Input;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        Task<List<ProductAdd>> GetProduct();
        Task<int> SaveProduct(ProductAdd Product);
        Task<ProductAdd> GetProductById(int ProductId);
        Task DeleteProduct(int ProductId);
    }


    public class ProductRepository : IProductRepository
    {
        private readonly ISQLServerHandler _SQLServerHandler;

        public ProductRepository(ISQLServerHandler sQLServerHandler)
        {
            _SQLServerHandler = sQLServerHandler;
        }

        public async Task<List<ProductAdd>> GetProduct()
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ActionId", 3, DbType.Int32, ParameterDirection.Input);
            return (await _SQLServerHandler.QueryAsync<ProductAdd>(_SQLServerHandler.Connection, StroredProc.GetProduct, CommandType.StoredProcedure, parameters)).ToList();
        }
        public async Task<int> SaveProduct(ProductAdd Product)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ActionId", 1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ProductId", Product.ProductId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Brand", Product.Brand, DbType.String, ParameterDirection.Input);
            parameters.Add("@Model", Product.Model, DbType.String, ParameterDirection.Input);
            parameters.Add("@Price", Product.Price, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Discount", Product.Discount, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Specification", Product.Specification, DbType.String, ParameterDirection.Input);
            parameters.Add("@QtyinStock", Product.QtyinStock, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Rating", Product.Rating, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("@Colour", Product.Colour, DbType.String, ParameterDirection.Input);
            parameters.Add("@Storage", Product.Storage, DbType.String, ParameterDirection.Input);
            parameters.Add("@Image", Product.Image, DbType.String, ParameterDirection.Input);
            parameters.Add("@returnVal", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _SQLServerHandler.ExecuteAsync(_SQLServerHandler.Connection, StroredProc.GetProduct, CommandType.StoredProcedure, parameters);
            return parameters.Get<int>("@returnVal");
        }
        public async Task<ProductAdd> GetProductById(int ProductId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ActionId", 3, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ProductId", ProductId, DbType.Int32, ParameterDirection.Input);
            return await _SQLServerHandler.QueryFirstOrDefaultAsync<ProductAdd>(_SQLServerHandler.Connection, StroredProc.GetProduct, CommandType.StoredProcedure, parameters);
        }
        public async Task DeleteProduct(int ProductId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ActionId", 2, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ProductId", ProductId, DbType.Int32, ParameterDirection.Input);
            await _SQLServerHandler.ExecuteAsync(_SQLServerHandler.Connection, StroredProc.GetProduct, CommandType.StoredProcedure, parameters);
        }

    }
}
