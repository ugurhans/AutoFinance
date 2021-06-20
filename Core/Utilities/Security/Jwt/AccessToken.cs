using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrate;

namespace Core.Utilities.Security.Jwt
{
    public class AccessToken
    {
        public User user { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
