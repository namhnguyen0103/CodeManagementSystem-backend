using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.UserProduct;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using API.Mappers;

namespace API.Repository
{
    public class UserProductRepository : IUserProductRepository
    {
        private readonly ApplicationDBContext _context;

        public UserProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public async Task<UserProduct?> CreateAsync(AddUserProductRequestDto userProductDto)
        {
            var userProductModel = userProductDto.ToUserProductFromRequest();
            DateTime expirationDate = userProductModel.Expiration_date;
            string day = expirationDate.Day.ToString("X2");
            string month = expirationDate.Month.ToString("X2");
            string year = expirationDate.Year.ToString("X4");
            string activationCode = day + month + year;
            activationCode = int.Parse(activationCode, System.Globalization.NumberStyles.HexNumber).ToString();
            activationCode = activationCode.Substring(activationCode.Length- 5);
            activationCode = activationCode + userProductDto.Customer_id.Substring(0,3) + userProductDto.Product_id.ToString("X2");

            userProductModel.Activation_code = activationCode.ToUpper();
            Random random = new Random();
            userProductModel.Mid = random.Next(0, 1000000000);
            userProductModel.Sitecode = random.Next(0, 1000000000);

            await _context.User_Product.AddAsync(userProductModel);
            await _context.SaveChangesAsync();
            return userProductModel;
        }

        public async Task<List<UserProduct>> GetAllAsync()
        {
            return await _context.User_Product.ToListAsync();
        }

        public async Task<UserProduct?> GetByIdAsync(int id)
        {
            return await _context.User_Product.FindAsync(id);
        }

        public async Task<List<UserProduct>> GetByUserIdAsync(string user_id)
        {
            var userProducts = _context.User_Product.Where(x => x.Customer_id == user_id && x.Deleted_at == null);
            return await userProducts.ToListAsync();
        }

        public async Task<bool> RenewUserProductAsync(int id, int duration)
        {
            var existingUserProduct = await DeleteByIdAsync(id);
            if (existingUserProduct != null)
            {
                var userProductDto = new AddUserProductRequestDto
                {
                    Customer_id = existingUserProduct.Customer_id,
                    Product_id = existingUserProduct.Product_id,
                    Duration = duration
                };
                var result = await CreateAsync(userProductDto);
                if (result != null) return true;
            }
            return false;
        }

        public async Task<UserProduct?> DeleteByIdAsync(int id)
        {
            var existingUserProduct = await _context.User_Product.FindAsync(id);
            
            if (existingUserProduct == null) return null;

            existingUserProduct.Deleted_at = DateTime.Now;

            await _context.SaveChangesAsync();
            return existingUserProduct;
        }

        public async Task<bool> UpdateRequestedByIdAsync(int id)
        {
            var existingUserProduct = await _context.User_Product.FindAsync(id);
            if (existingUserProduct == null) return false;

            existingUserProduct.Requested = !existingUserProduct.Requested;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}