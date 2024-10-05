using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        
        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productRepo.GetAllAsync();
            var productsDto = products.Select(x => x.ToProductDto());

            return Ok(productsDto);
        }

        /// <summary>
        /// Finds product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            if (product == null) return NotFound();
            
            return Ok(product.ToProductDto());
        }
    }
}