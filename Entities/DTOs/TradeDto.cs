﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class TradeDto : IDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }
        public DateTime SellDate { get; set; }
        public int TradeAmount { get; set; }
        public string CustomerName { get; set; }
        public string SupplierName { get; set; }
    }
}