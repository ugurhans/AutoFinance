using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrate
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

    }
}
