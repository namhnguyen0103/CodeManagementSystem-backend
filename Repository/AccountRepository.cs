using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.Account;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDBContext _context;

        public AccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AccountExistsAsync(string id)
        {
            return await _context.Accounts.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> CustomerLoginAsync(string id, string password)
        {

            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return false;
            if (account.Password == password && account.Account_role == 3) return true;
            return false;
        }

        public async Task<bool> CustomerRegisterAsync(CreateAccountDto accountDto)
        {
            var exists = await AccountExistsAsync(accountDto.Id);
            if (exists == false)
            {
                var newAccount = accountDto.ToCustomerAccount();
                await _context.Accounts.AddAsync(newAccount);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<List<Account>> GetAdminAccountsAsync()
        {
            return await _context.Accounts.Where(x => x.Account_role != 3).ToListAsync();
        }
        public async Task<List<Account>> GetCustomerAccountsAsync()
        {
            return await _context.Accounts.Where(x => x.Account_role == 3).ToListAsync();
        }

        public async Task<bool> AdminRegisterAsync(CreateAccountDto accountDto)
        {
            var exists = await AccountExistsAsync(accountDto.Id);
            if (exists == false)
            {
                var newAccount = accountDto.ToAdminAccount();
                await _context.Accounts.AddAsync(newAccount);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> SuperAdminRegisterAsync(CreateAccountDto accountDto)
        {
            var exists = await AccountExistsAsync(accountDto.Id);
            if (exists == false)
            {
                var newAccount = accountDto.ToSuperAdmin();
                await _context.Accounts.AddAsync(newAccount);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> AdminLoginAsync(string id, string password)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null) return false;
            if (account.Password == password && account.Account_role < 3 ) return true;
            return false;
        }

        public async Task<Account?> GetByIdAsync(string id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null) return account;
            return null;
        }
    }
}