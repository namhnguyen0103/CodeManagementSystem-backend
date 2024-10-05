using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Product;
using API.Models;

namespace API.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product sp)
        {
            return new ProductDto
            {
                Id = sp.Id,
                Product_name = sp.Product_name,
                Product_description = sp.Product_description,
                PricePerMonth = sp.Price,
                Img = sp.Img
            };
        }
    }
}