using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.CartItem
{
    public class UpdateCartItemRequestDto
    {
        public int Duration { get; set; }

        public bool Selected { get; set; }
    }
}