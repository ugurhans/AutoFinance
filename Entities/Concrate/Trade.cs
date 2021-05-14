using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrate
{
    public class Trade : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }
        public DateTime SellDate { get; set; }
        public int TradeAmount { get; set; }
        public decimal TradePrice { get; set; }
    }
}
