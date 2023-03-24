using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Services
{
    using ECommerce.Models;
    using ECommerce.Models.Input;
    using ECommerce.Repository;
    using System;
    using System.Threading.Tasks;

    public interface IUserDetailService
    {
        Task<ResultArgs> GetUser();
        Task<ResultArgs> GetDistricts();
        Task<ResultArgs> SaveUser(UserDetail User);
        Task<ResultArgs> DeleteUser(int UserId);


    }
    public class UserDetailService : IUserDetailService
    {
        private readonly IUserDetailRepository _UserDetailRepository;

        public UserDetailService(IUserDetailRepository UserDetailRepository)
        {
            this._UserDetailRepository = UserDetailRepository;
        }
        public async Task<ResultArgs> GetUser()
        {
            var RresultArgs = new ResultArgs();

            var UserDetailResult = await _UserDetailRepository.GetUser();

            if (UserDetailResult != null)
            {
                RresultArgs.StatusCode = 200;
                RresultArgs.StatusMessage = "Record is success";
                RresultArgs.ResultData = UserDetailResult;
            }
            else
            {
                RresultArgs.StatusCode = 205;
                RresultArgs.StatusMessage = "Failed to save";
            }
            return RresultArgs;
        }

        public async Task<ResultArgs> SaveUser(UserDetail User)
        {
            var RresultArgs = new ResultArgs();

            var UserId = await _UserDetailRepository.SaveUser(User);
            if (UserId > 0)
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

        public async Task<ResultArgs> DeleteUser(int UserId)
        {
            var RresultArgs = new ResultArgs();

            await _UserDetailRepository.DeleteUser(UserId);

            RresultArgs.StatusCode = 200;
            RresultArgs.StatusMessage = "Deleted success";

            return RresultArgs;
        }
        public async Task<ResultArgs> GetDistricts()
        {
            var RresultArgs = new ResultArgs();

            var UserDetailResult = await _UserDetailRepository.GetUser();

            if (UserDetailResult != null)
            {
                RresultArgs.StatusCode = 200;
                RresultArgs.StatusMessage = "Record is success";
                RresultArgs.ResultData = UserDetailResult;
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
