using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Core.Entities;

namespace Core.Entities.Concrate
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public string TcNo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
