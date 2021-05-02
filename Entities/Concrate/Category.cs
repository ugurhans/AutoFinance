using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrate
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

    }
}
