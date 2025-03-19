﻿using SovosProject.Core.Aggregates.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SovosProject.Application.Models
{
    public class InvoiceHeaderDto
    {
        public int Id { get; set; }
        public string InvoiceId { get;  set; }
        public string SenderTitle { get;  set; }
        public string ReceiverTitle { get;  set; }
        public DateTime Date { get;  set; }
        public string Email { get;  set; }
        public List<InvoiceLineDto> InvoiceLines { get; set; } = new();
    }
}
