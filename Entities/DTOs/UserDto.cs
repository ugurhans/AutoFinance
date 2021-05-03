using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

    }
}
