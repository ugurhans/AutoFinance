using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public int StockAmount { get; set; }
        public string Description { get; set; }
        public string SupplierName { get; set; }
        public bool ToVerify { get; set; }
    }
}
