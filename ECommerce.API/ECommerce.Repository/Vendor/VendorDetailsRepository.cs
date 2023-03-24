namespace ECommerce.Repository.Vendor
{
    using Dapper;
    using ECommerce.Common;
    using ECommerce.DBEngine;
    using ECommerce.Models.Input.Vendor;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IVendorDetailsRepository
    {
        Task<List<VendorDetails>> GetVendor();
        Task<int> SaveVendor(VendorDetails Vendor);
        Task DeleteVendor(int VendorId);

    }
    public class VendorDetailsRepository : IVendorDetailsRepository
    {
        private readonly ISQLServerHandler _SQLServerHandler;

        public VendorDetailsRepository(ISQLServerHandler sQLServerHandler)
        {
            _SQLServerHandler = sQLServerHandler;
        }

        public async Task<List<VendorDetails>> GetVendor()
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
            return (await _SQLServerHandler.QueryAsync<VendorDetails>(_SQLServerHandler.Connection, StroredProc.VendorDetails, CommandType.StoredProcedure, parameters)).ToList();
        }

        public async Task<int> SaveVendor(VendorDetails Vendor)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@ActionId", 1, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@VendorId", Vendor.VendorId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@VendorName", Vendor.VendorName, DbType.String, ParameterDirection.Input);
                parameters.Add("@TypeofProduct", Vendor.TypeofProduct, DbType.String, ParameterDirection.Input);
                parameters.Add("@MobileNumber", Vendor.MobileNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("@Address", Vendor.Address, DbType.String, ParameterDirection.Input);
                parameters.Add("@City", Vendor.City, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Districk", Vendor.Districk, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@State", Vendor.State, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Pincode", Vendor.Pincode, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@RegisterOn", Vendor.RegisterOn, DbType.Date, ParameterDirection.Input);
                parameters.Add("@ActivatedOn", Vendor.ActivatedOn, DbType.Date, ParameterDirection.Input);
                parameters.Add("@YearlySubscription", Vendor.YearlySubscription, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@Status", Vendor.Status, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Nextdue", Vendor.Nextdue, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("@returnVal", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _SQLServerHandler.ExecuteAsync(_SQLServerHandler.Connection, StroredProc.VendorDetails, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.SendErrorToText(ex);
            }

            return parameters.Get<int>("@returnVal");

        }


        public async Task DeleteVendor(int VendorId)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@ActionId", 3, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@VendorId", VendorId, DbType.Int32, ParameterDirection.Input);
                await _SQLServerHandler.ExecuteAsync(_SQLServerHandler.Connection, StroredProc.VendorDetails, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.SendErrorToText(ex);
            }
        }

    }
}
