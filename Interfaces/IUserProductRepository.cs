using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.UserProduct;
using API.Models;

namespace API.Interfaces
{
    public interface IUserProductRepository
    {
        Task<List<UserProduct>> GetAllAsync();
        Task<List<UserProduct>> GetByUserIdAsync(string user_id);
        Task<UserProduct?> GetByIdAsync(int id);
        Task<UserProduct?> CreateAsync(AddUserProductRequestDto userProductDto);
        Task<bool> RenewUserProductAsync(int id, int duration);
        Task<UserProduct?> DeleteByIdAsync(int id);
        Task<bool> UpdateRequestedByIdAsync(int id);
    }
}