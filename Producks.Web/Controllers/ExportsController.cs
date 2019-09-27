using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producks.Data;
using Producks.Web.Models;

namespace Producks.Web.Controllers
{
    [ApiController]
    public class ExportsController : ControllerBase
    {
        private readonly StoreDb _context;

        public ExportsController(StoreDb context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet("api/Brands")]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _context.Brands
                                       .Select(b => new BrandDto
                                       {
                                           Id = b.Id,
                                           Name = b.Name,
                                           Active = b.Active
                                       })
                                       .ToListAsync();

            return Ok(brands);
        }

        // GET: api/Categories
        [HttpGet("api/Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories
                                    .Select(b => new CategoryDTO
                                    {
                                        Id = b.Id,
                                        Name = b.Name,
                                        Description =b.Description,
                                        Active = b.Active
                                    })
                                    .ToListAsync();
            return Ok(categories);
        }
    }
}
