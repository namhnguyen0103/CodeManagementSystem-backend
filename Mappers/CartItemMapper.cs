using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.CartItem;
using API.Models;

namespace API.Mappers
{
    public static class CartItemMapper
    {
        public static CartItem ToCartItem(this CartItemDto cartItemDto)
        {
            return new CartItem
            {
                Id = cartItemDto.Id,
                Customer_id = cartItemDto.Customer_id,
                Product_id = cartItemDto.Product_id,
                Duration = cartItemDto.Duration,
                Selected = cartItemDto.Selected
            };
        }

        public static CartItem ToCartItem(this AddCartItemRequestDto cartItemDto)
        {
            return new CartItem
            {
                Customer_id = cartItemDto.Customer_id,
                Product_id = cartItemDto.Product_id,
                Duration = cartItemDto.Duration,
                Selected = cartItemDto.Selected
            };
        }

        public static CartItemDto ToCartItemDto(this CartItem cartItem)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                Customer_id = cartItem.Customer_id,
                Product_id = cartItem.Product_id,
                Duration = cartItem.Duration,
                Selected = cartItem.Selected
            };
        }

        public static UpdateCartItemRequestDto ToUpdateCartItemDto(this CartItemDto cartItemDto)
        {
            return new UpdateCartItemRequestDto
            {
                Selected = cartItemDto.Selected,
                Duration = cartItemDto.Duration
            };
        }
    }
}