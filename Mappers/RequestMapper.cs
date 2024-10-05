using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Request;
using API.Models;

namespace API.Mappers
{
    public static class RequestMapper
    {
        public static Request ToRequest(this CreateRequestDto requestDto)
        {
            return new Request
            {
                Product_id = requestDto.Product_id,
                Duration = requestDto.Duration,
                Created_at = DateTime.Now
            };
        }

        public static Request ToRequest(this UpdateRequestDto requestDto)
        {
            return new Request
            {
                Id = requestDto.Id,
                Is_approved = requestDto.IsApproved,
                Approved_by = requestDto.ApprovedBy,
                Updated_at = DateTime.Now
            
            };
        }
        public static RequestDto ToRequestDto(this Request requestModel)
        {
            return new RequestDto
            {
                Id = requestModel.Id,
                Product_id = requestModel.Product_id,
                Duration = requestModel.Duration,
                IsApproved = requestModel.Is_approved,
                ApprovedBy = requestModel.Approved_by,
                Created_at = requestModel.Created_at
            };
        }
    }
}