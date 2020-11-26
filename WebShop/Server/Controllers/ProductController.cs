using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            Product product = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if(product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }
    }
}
