using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class TradeDto : IDto
    {
        public int Id { get; set; }
        public DateTime SellDate { get; set; }
        public int TradeAmount { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public decimal TradePrice { get; set; }
    }
}
