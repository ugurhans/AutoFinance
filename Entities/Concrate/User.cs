using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrate
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
