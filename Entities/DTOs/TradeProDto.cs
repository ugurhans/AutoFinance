using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class TradeProDto : IDto
    {
        public int OrderId { get; set; }
        public string OrderProductName { get; set; }
        public int OrderAmount { get; set; }
        public int OrderUserId { get; set; }
        public decimal OrderPrice { get; set; }


        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStockAmount { get; set; }
        public string ProductDescription { get; set; }
        public int ProductSupplierId { get; set; }
        public bool ProductToVerify { get; set; }


        public int CustomerWalletId { get; set; }
        public int CustomerWalletUserId { get; set; }
        public string CustomerWalletUserName { get; set; }
        public string CustomerWalletUserLastName { get; set; }
        public decimal CustomerWalletBalance { get; set; }
        public bool CustomerWalletToVerify { get; set; }


        public int SupplierWalletId { get; set; }
        public int SupplierWalletUserId { get; set; }
        public string SupplierWalletUserName { get; set; }
        public string SupplierWalletUserLastName { get; set; }
        public decimal SupplierWalletBalance { get; set; }
        public bool SupplierWalletToVerify { get; set; }

    }
}
