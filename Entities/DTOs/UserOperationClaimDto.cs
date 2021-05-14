using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Entities.Concrate;

namespace Entities.DTOs
{
    public class UserOperationClaimDto : IDto
    {
        public int UserId { get; set; }

        public string OperationClaimName { get; set; }
    }
}
