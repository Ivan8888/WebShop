﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<InvoiceIteam> InvoiceIteams { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
