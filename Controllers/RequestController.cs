using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.Account;
using API.Dtos.Request;
using API.Dtos.UserProduct;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("requests")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository _requestRepo;
        private readonly IUserProductRepository _userProductRepo;
        private readonly IAccountRepository _accountRepo;
        private readonly IProductRepository _productRepo;

        public RequestController(IRequestRepository requestRepo, IUserProductRepository userProductRepo, IAccountRepository accountRepo, IProductRepository productRepo)
        {
            _requestRepo = requestRepo;
            _userProductRepo = userProductRepo;
            _accountRepo = accountRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var requests = await _requestRepo.GetAllAsync();
            var requestsDto = requests.Select(request => request.ToRequestDto()).ToList();

            foreach(RequestDto request in requestsDto)
            {
                var userProduct = await _userProductRepo.GetByIdAsync(request.Product_id);
                if (userProduct == null) return NotFound();
                
                request.OldActivationCode = userProduct.Activation_code;
                request.OldExpirationDate = userProduct.Expiration_date;
                request.NewExpirationDate = DateTime.Now.AddMonths(request.Duration);
                request.Customer_id = userProduct.Customer_id;
                Product? product = await _productRepo.GetByIdAsync(userProduct.Product_id);
                if (product != null) request.Product_name = product.Product_name;
                Account? account = await _accountRepo.GetByIdAsync(userProduct.Customer_id);
                if (account != null) request.Customer_name = account.Account_name;
            }
            return Ok(requestsDto);
        }

        [HttpGet("getWaitingRequests")]
        public async Task<IActionResult> GetWaitingRequestsAsync()
        {
            var requests = await _requestRepo.GetWaitingRequests();
            var requestsDto = requests.Select(request => request.ToRequestDto()).ToList();

            foreach(RequestDto request in requestsDto)
            {
                var userProduct = await _userProductRepo.GetByIdAsync(request.Product_id);
                if (userProduct == null) return NotFound();
                
                request.OldActivationCode = userProduct.Activation_code;
                request.OldExpirationDate = userProduct.Expiration_date;
                request.NewExpirationDate = DateTime.Now.AddMonths(request.Duration);
                request.Customer_id = userProduct.Customer_id;
                Product? product = await _productRepo.GetByIdAsync(userProduct.Product_id);
                if (product != null) request.Product_name = product.Product_name;
                Account? account = await _accountRepo.GetByIdAsync(userProduct.Customer_id);
                if (account != null) request.Customer_name = account.Account_name;
            }
            return Ok(requestsDto);
        }

        [HttpPost("createRequest")]
        public async Task<IActionResult> CreateRequestAsync([FromBody] CreateRequestDto requestDto)
        {
            if (requestDto != null)
            {
                var result = await _requestRepo.CreateAsync(requestDto);
                if (result) 
                {
                    await _userProductRepo.UpdateRequestedByIdAsync(requestDto.Product_id);
                    return Ok(result);
                }
                else return BadRequest("Can't create request");
            }
            return BadRequest("Invalid request");
        }

        [HttpPut("updateRequest")]
        public async Task<IActionResult> UpdateRequestAsync([FromBody] UpdateRequestDto requestDto)
        {
            var request = await _requestRepo.GetByIdAsync(requestDto.Id);
            if (request == null) return NotFound("Request not found");
            if (requestDto.IsApproved == true)
            {
                var renewResult = await _userProductRepo.RenewUserProductAsync(request.Product_id, request.Duration);
                if (renewResult == false)
                    return BadRequest("Could not renew product");
            }
            else
            {
                var updateResult = await _userProductRepo.DeleteByIdAsync(request.Product_id);
                if (updateResult == null)
                    return BadRequest("Could not delete product");
            }
            await _requestRepo.UpdateAsync(requestDto);
            return Ok(true);
        }
    }
}