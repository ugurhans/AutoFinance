using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrate;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult Add(UserOperationClaim userOperationClaim);
    }
}
