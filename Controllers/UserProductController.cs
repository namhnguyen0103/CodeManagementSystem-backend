using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.UserProduct;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("user_products")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
        private readonly IUserProductRepository _userProductRepo;

        public UserProductController(IUserProductRepository userProductRepo)
        {
            _userProductRepo = userProductRepo;
        }

        /// <summary>
        /// Returns all user products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var userProducts = await _userProductRepo.GetAllAsync();
            var userProductsDto = userProducts.Select(x => x.ToUserProductDto());
            return Ok(userProductsDto);
        }

        /// <summary>
        /// Gets user products by customer ID
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        [HttpGet("getByUserId/{user_id}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string user_id)
        {
            var userProducts = await _userProductRepo.GetByUserIdAsync(user_id);
            var userProductsDto = userProducts.Select(x => x.ToUserProductDto());
            return Ok(userProductsDto);
        }

        /// <summary>
        /// Gets a user product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var userProduct = await _userProductRepo.GetByIdAsync(id);
            if (userProduct == null) return NotFound();
            return Ok(userProduct.ToUserProductDto());
        }

        /// <summary>
        /// Creates a new user product
        /// </summary>
        /// <param name="userProductDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUserProductAsync([FromBody] AddUserProductRequestDto userProductDto)
        {
            var returned = await _userProductRepo.CreateAsync(userProductDto);
            return Ok(returned);
        }

        [HttpPut]
        public async Task<IActionResult> ChangeRequested([FromBody] int id)
        {
            var result = await _userProductRepo.UpdateRequestedByIdAsync(id);
            if (result == false) return NotFound();
            return Ok(result);
        }

    }
}