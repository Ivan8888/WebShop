using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        DataContext _context;

        public InvoiceController(DataContext context)
        {
            _context = context;
        }

        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            //Product product = _context.Products.SingleOrDefault(p => p.ProductId == id);

            //explicit loading
            //Invoice invoice_explicit = _context.Invoices.SingleOrDefault(i => i.InvoiceId == id);
            //_context.Entry(invoice_explicit)
            //    .Reference(i => i.Customer)
            //    .Load();
            //_context.Entry(invoice_explicit)
            //    .Collection(i => i.InvoiceItems)
            //    .Load();



            //eager loading
            Invoice invoice_eager = _context.Invoices
                                    .Include(i => i.Customer)
                                    .Include(i => i.InvoiceItems)
                                        .ThenInclude(i => i.Product)
                                    .SingleOrDefault(i => i.InvoiceId == id);

            return Ok(invoice_eager);

            //lazy loading
        }
    }
}
