using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Account;
using API.Models;

namespace API.Mappers
{
    public static class AccountMapper
    {
        public static Account ToCustomerAccount(this CreateAccountDto account)
        {
            return new Account
            {
                Id = account.Id,
                Account_name = account.Account_name,
                Email = account.Email,
                Password = account.Account_password,
                Account_role = 3,
                Date_of_birth = account.Date_of_birth
            };
        }
        public static Account ToSuperAdmin(this CreateAccountDto account)
        {
            return new Account
            {
                Id = account.Id,
                Account_name = account.Account_name,
                Email = account.Email,
                Password = account.Account_password,
                Account_role = 1,
                Date_of_birth = account.Date_of_birth
            };
        }
        public static Account ToAdminAccount(this CreateAccountDto account)
        {
            return new Account
            {
                Id = account.Id,
                Account_name = account.Account_name,
                Email = account.Email,
                Password = account.Account_password,
                Account_role = 2,
                Date_of_birth = account.Date_of_birth
            };
        }

        public static AccountDto ToAccountDto(this Account accountModel)
        {
            return new AccountDto
            {
                Id = accountModel.Id,
                Account_name = accountModel.Account_name,
                Email = accountModel.Email,
                Account_role = accountModel.Account_role,
                Date_of_birth = accountModel.Date_of_birth
            };
        }

        public static AdminAccountDto ToAdminAccountDto(this Account accountModel)
        {
            return new AdminAccountDto
            {
                AdminId = accountModel.Id,
                Name = accountModel.Account_name,
                Email = accountModel.Email,
                SuperAdmin = accountModel.Account_role == 1
            };
        }
    }
}