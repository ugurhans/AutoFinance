using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrate;

namespace Entities.DTOs
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public decimal Wallet { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


    }
}
