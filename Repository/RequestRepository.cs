using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.Request;
using API.Interfaces;
using API.Mappers;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDBContext _context;

        public RequestRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(CreateRequestDto requestDto)
        {
            var exists = await RequestExistsByProductId(requestDto.Product_id);
            if (exists == false)
            {
                var newRequest = requestDto.ToRequest();
                await _context.Requests.AddAsync(newRequest);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Request>> GetAllAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request?> GetByIdAsync(int id)
        {
            return await _context.Requests.FindAsync(id);
        }

        public async Task<List<Request>> GetWaitingRequests()
        {
            return await _context.Requests.Where(x => x.Is_approved == null).ToListAsync();
        }

        public async Task<bool> RequestExistsById(int id)
        {
             return await _context.Requests.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> RequestExistsByProductId(int product_id)
        {
            return await _context.Requests.AnyAsync(x => x.Product_id == product_id);
        }

        public async Task<Request?> UpdateAsync(UpdateRequestDto requestDto)
        {
            var existingRequest = await _context.Requests.FindAsync(requestDto.Id);
            
            if (existingRequest == null) return null;

            existingRequest.Is_approved = requestDto.IsApproved;
            existingRequest.Approved_by = requestDto.ApprovedBy;
            existingRequest.Approved_at = DateTime.Now;
            existingRequest.Deleted_at = DateTime.Now;


            await _context.SaveChangesAsync();
            return existingRequest;
        }
    }
}