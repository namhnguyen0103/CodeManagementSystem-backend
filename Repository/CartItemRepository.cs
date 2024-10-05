using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.CartItem;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly ApplicationDBContext _context;

        public CartItemRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CartItem?> CreateAsync(CartItem cartItemModel)
        {
            await _context.Cart_Item.AddAsync(cartItemModel);
            await _context.SaveChangesAsync();
            return cartItemModel;
        }

        public async Task<CartItem?> DeleteAsync(int id)
        {
            var cartItemModel = await _context.Cart_Item.FirstOrDefaultAsync(x => x.Id == id);

            if (cartItemModel == null) return null;

            _context.Cart_Item.Remove(cartItemModel);
            await _context.SaveChangesAsync();
            return cartItemModel; 
        }

        public async Task<List<CartItem>> GetAllAsync()
        {
            return await _context.Cart_Item.ToListAsync();
        }

        public async Task<CartItem?> GetByIdAsync(int id)
        {
            return await _context.Cart_Item.FindAsync(id);
        }

        public async Task<List<CartItem>> GetByUserIdAsync(string user_id)
        {
            var userCartItem = _context.Cart_Item.Where(x => x.Customer_id == user_id);
            return await userCartItem.ToListAsync();
        }

        public async Task<CartItem?> UpdateAsync(int id, UpdateCartItemRequestDto cartItemDto)
        {
            var existingCartItem = await _context.Cart_Item.FindAsync(id);
            
            if (existingCartItem == null) return null;

            existingCartItem.Selected = cartItemDto.Selected;
            existingCartItem.Duration = cartItemDto.Duration;

            await _context.SaveChangesAsync();
            return existingCartItem;
        }
    }
}