using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class OrderDto : IDto
    {
        public int OrderId { get; set; }
        public string OrderProductName { get; set; }
        public int OrderAmount { get; set; }
        public string CustomerName { get; set; }
        public decimal OrderPrice { get; set; }

    }
}
