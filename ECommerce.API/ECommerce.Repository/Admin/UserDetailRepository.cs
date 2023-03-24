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

    public interface IUserDetailRepository
    {
        Task<List<UserDetail>> GetUser();
        Task<int> SaveUser(UserDetail User);
        Task DeleteUser(int UserId);

    }
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly ISQLServerHandler _SQLServerHandler;

        public UserDetailRepository(ISQLServerHandler sQLServerHandler)
        {
            _SQLServerHandler = sQLServerHandler;
        }

        public async Task<List<UserDetail>> GetUser()
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
            return (await _SQLServerHandler.QueryAsync<UserDetail>(_SQLServerHandler.Connection, StroredProc.UserDetails, CommandType.StoredProcedure, parameters)).ToList();
        }

        public async Task<int> SaveUser(UserDetail User)
        {
            var parameters = new DynamicParameters();
            try
            {
                //UserId, UserRole, FirstName, LastName, MobileNumber, Email, Password, Address, City, Districk, State, Pincode, IdentityProof, IsDeleted
                parameters.Add("@ActionId", 1, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@UserId", User.UserId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@UserRole", User.UserRole, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@FirstName", User.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LastName", User.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@MobileNumber", User.MobileNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("@Password", User.Password, DbType.String, ParameterDirection.Input);
                parameters.Add("@Address", User.Address, DbType.String, ParameterDirection.Input);
                parameters.Add("@City", User.City, DbType.String, ParameterDirection.Input);
                parameters.Add("@Districk", User.Districk, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@State", User.State, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Pincode", User.Pincode, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@IdentityProof", User.IdentityProof, DbType.String, ParameterDirection.Input); 
                parameters.Add("@returnVal", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await _SQLServerHandler.ExecuteAsync(_SQLServerHandler.Connection, StroredProc.UserDetails, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.SendErrorToText(ex);
            }

            return parameters.Get<int>("@returnVal");

        }


        public async Task DeleteUser(int UserId)
        {
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("@ActionId", 3, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@UserId", UserId, DbType.Int32, ParameterDirection.Input);
                await _SQLServerHandler.ExecuteAsync(_SQLServerHandler.Connection, StroredProc.UserDetails, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.SendErrorToText(ex);
            }
        }

    }
}
