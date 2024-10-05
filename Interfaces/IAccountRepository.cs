using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Account;
using API.Models;

namespace API.Interfaces
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<List<Account>> GetAdminAccountsAsync();
        Task<List<Account>> GetCustomerAccountsAsync();
        Task<Account?> GetByIdAsync(string id);
        Task<bool> AccountExistsAsync(string id);
        Task<bool> CustomerLoginAsync(string id, string password);
        Task<bool> CustomerRegisterAsync(CreateAccountDto accountDto);
        Task<bool> AdminRegisterAsync(CreateAccountDto accountDto);
        Task<bool> SuperAdminRegisterAsync(CreateAccountDto accountDto);
        Task<bool> AdminLoginAsync(string id, string password);
    }
}