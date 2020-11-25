using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class InvoiceIteam
    {
        public int InvoiceIteamId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
