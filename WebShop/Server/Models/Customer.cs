using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
