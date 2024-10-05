using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.Account;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("accounts")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepo;

        public AccountController(IAccountRepository accountRepo)
        {
            _accountRepo = accountRepo;
        }

        /// <summary>
        /// Returns all accounts
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var accounts = await _accountRepo.GetAllAsync();
            var accountsDto = accounts.Select(x => x.ToAccountDto());
            return Ok(accountsDto);
        }

        /// <summary>
        /// Returns all customer accounts
        /// </summary>
        [HttpGet]
        [Route("getCustomerAccounts")]
        public async Task<IActionResult> GetCustomerAccounts()
        {
            var accounts = await _accountRepo.GetCustomerAccountsAsync();
            var accountsDto = accounts.Select(x => x.ToAccountDto());
            return Ok(accountsDto);
        }

        /// <summary>
        /// Returns all admin accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAdminAccounts")]
        public async Task<IActionResult> GetAdminAccounts()
        {
            var accounts = await _accountRepo.GetAdminAccountsAsync();
            var accountsDto = accounts.Select(x => x.ToAdminAccountDto());
            return Ok(accountsDto);
        }

        /// <summary>
        /// Logs customer into system
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("customerLogin")]
        public async Task<IActionResult> CustomerLoginAsync([FromBody] LoginDto loginInfo)
        {
            var result = await _accountRepo.CustomerLoginAsync(loginInfo.Id, loginInfo.Account_password);
            return Ok(result);
        }

        /// <summary>
        /// Registers a customer account
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("customerRegister")]
        public async Task<IActionResult> CustomerRegisterAsync([FromBody] CreateAccountDto accountDto)
        {
            if (accountDto != null)
            {
                var result = await _accountRepo.CustomerRegisterAsync(accountDto);
                if (result) return Ok(result);
                else return BadRequest("Account already exists");
            }
            return BadRequest("Invalid account");
        }

        /// <summary>
        /// Registers an admin account
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("adminRegister")]
        public async Task<IActionResult> AdminRegisterAsync([FromBody] CreateAccountDto accountDto)
        {
            if (accountDto != null)
            {
                var result = await _accountRepo.AdminRegisterAsync(accountDto);
                if (result) return Ok(result);
                else return BadRequest("Account already exists");
            }
            return BadRequest("Invalid account");
        }

        /// <summary>
        /// Registers a super admin account
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("superAdminRegister")]
        public async Task<IActionResult> SuperAdminRegisterAsync([FromBody] CreateAccountDto accountDto)
        {
            if (accountDto != null)
            {
                var result = await _accountRepo.SuperAdminRegisterAsync(accountDto);
                if (result) return Ok(result);
                else return BadRequest("Account already exists");
            }
            return BadRequest("Invalid account");
        }

        /// <summary>
        /// Logs admin into system
        /// </summary>
        /// <param name="loginInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("adminLogin")]
        public async Task<IActionResult> AdminLogin([FromBody] LoginDto loginInfo)
        {
            var result = await _accountRepo.AdminLoginAsync(loginInfo.Id, loginInfo.Account_password);
            return Ok(result);
        }
    }
}