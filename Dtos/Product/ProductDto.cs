using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Product
{
    public class ProductDto
    {
    public int Id { get; set; }

    public string Product_name { get; set; } = string.Empty;

    public string Product_description { get; set; } = string.Empty;

    public decimal PricePerMonth { get; set; }

    public string? Img { get; set; } = string.Empty;
    }
}