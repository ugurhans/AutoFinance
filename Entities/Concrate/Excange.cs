using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrate
{
    public class Excange : IEntity
    {
        public string Name { get; set; }
        public string Buying { get; set; }
        public string Selling { get; set; }
    }
}
