using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.CartItem;
using API.Models;

namespace API.Interfaces
{
    public interface ICartItemRepository
    {
        Task<List<CartItem>> GetAllAsync();
        Task<CartItem?> GetByIdAsync(int id);
        Task<List<CartItem>> GetByUserIdAsync(string user_id);
        Task<CartItem?> UpdateAsync(int id, UpdateCartItemRequestDto cartItemDto);
        Task<CartItem?> DeleteAsync(int id);
        Task<CartItem?> CreateAsync(CartItem cartItem);
    }
}