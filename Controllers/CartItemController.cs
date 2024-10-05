using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.CartItem;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("cart_item")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemRepository _cartItemRepo;
        private readonly IProductRepository _productRepo;
        private readonly IAccountRepository _accountRepo;
        public CartItemController(ICartItemRepository cartItemRepo, IProductRepository productRepo, IAccountRepository accountRepo)
        {
            _cartItemRepo = cartItemRepo;
            _productRepo = productRepo;
            _accountRepo = accountRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var cartItems = await _cartItemRepo.GetAllAsync();
            var cartItemsDto = cartItems.Select(x => x.ToCartItemDto());
            return Ok(cartItemsDto);
        }

        /// <summary>
        /// Creates a new cart item
        /// </summary>
        /// <param name="cartItemDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddCartItemRequestDto cartItemDto)
        {
            if(!await _productRepo.ProductExistsAsync(cartItemDto.Product_id))
            {
                return BadRequest("Product does not exist");
            }
            
            if(!await _accountRepo.AccountExistsAsync(cartItemDto.Customer_id))
            {
                return BadRequest("Account doesn't exist");
            }

            var cartItemModel = cartItemDto.ToCartItem();
            await _cartItemRepo.CreateAsync(cartItemModel);

            return CreatedAtAction(nameof(GetById), new { id = cartItemModel}, cartItemModel.ToCartItemDto());
        }

        /// <summary>
        /// Gets a cart item by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var cartItem = await _cartItemRepo.GetByIdAsync(id);
            if (cartItem == null) return NotFound();
            return Ok(cartItem.ToCartItemDto());
        }

        /// <summary>
        /// Gets cart items by customer ID
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        [HttpGet("getByUserId/{user_id}")]
        public async Task<IActionResult> GetByUserId([FromRoute] string user_id)
        {
            var cartItems = await _cartItemRepo.GetByUserIdAsync(user_id);
            var cartItemsDto = cartItems.Select(x => x.ToCartItemDto());
            return Ok(cartItemsDto);
        }

        /// <summary>
        /// Updates an existing cart item
        /// </summary>
        /// <param name="cartItemDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateById([FromBody] CartItemDto cartItemDto)
        {
            var cartItem = await _cartItemRepo.UpdateAsync(cartItemDto.Id, cartItemDto.ToUpdateCartItemDto());
            if (cartItem == null) return NotFound();
            return Ok(cartItem.ToCartItemDto());
        }

        /// <summary>
        /// Deletes a cart item by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            var cartItem = await _cartItemRepo.DeleteAsync(id);
            if (cartItem == null) return NotFound();
            return Ok(cartItem.ToCartItemDto());
        }
    }
}