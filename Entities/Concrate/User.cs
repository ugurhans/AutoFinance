using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrate
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public decimal Wallet { get; set; }
    }
}
