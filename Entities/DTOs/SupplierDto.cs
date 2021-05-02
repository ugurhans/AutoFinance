﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Concrate;

namespace Entities.DTOs
{
    public class SupplierDto : IDto
    {
        public int Id { get; set; }
        public decimal Wallet { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


    }
}
