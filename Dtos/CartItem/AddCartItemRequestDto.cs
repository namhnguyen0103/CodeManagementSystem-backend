using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.CartItem
{
    public class AddCartItemRequestDto
    {
        public string Customer_id { get; set; } = string.Empty;

        public int Product_id { get; set; }

        public int Duration { get; set; }

        public bool Selected { get; set; } = true;
    }
}