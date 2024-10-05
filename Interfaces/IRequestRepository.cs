using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Request;
using API.Models;

namespace API.Interfaces
{
    public interface IRequestRepository
    {
        Task<bool> RequestExistsById(int id);
        Task<bool> RequestExistsByProductId(int product_id);
        Task<List<Request>> GetAllAsync();
        Task<List<Request>> GetWaitingRequests();
        Task<Request?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateRequestDto requestDto);
        Task<Request?> UpdateAsync(UpdateRequestDto requestDto);
    }
}