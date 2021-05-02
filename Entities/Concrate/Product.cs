using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrate
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int StockAmount { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int SupplierId { get; set; }

    }
}
