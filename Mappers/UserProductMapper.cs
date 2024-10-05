using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.UserProduct;
using API.Models;

namespace API.Mappers
{
    public static class UserProductMapper
    {
        public static UserProductDto ToUserProductDto(this UserProduct userProductModel)
        {
            return new UserProductDto
            {
                Id = userProductModel.Id,
                Product_id = userProductModel.Product_id,
                ExpirationDate = userProductModel.Expiration_date,
                Mid = userProductModel.Mid,
                Sitecode = userProductModel.Sitecode,
                ActivationCode = userProductModel.Activation_code,
                Requested = userProductModel.Requested
            };
        }

        public static UserProduct ToUserProductFromRequest(this AddUserProductRequestDto userProductDto)
        {
            return new UserProduct
            {
                Customer_id = userProductDto.Customer_id,
                Product_id = userProductDto.Product_id,
                Expiration_date = System.DateTime.Now.AddMonths(userProductDto.Duration)
            };
        }
        
    }
}