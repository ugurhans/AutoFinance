using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrate
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string OrderProductName { get; set; }
        public int OrderAmount { get; set; }
        public int UserId { get; set; }

    }
}
