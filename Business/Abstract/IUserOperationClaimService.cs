using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrate;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(UserOperationClaim userOperationClaim);

        IDataResult<List<UserOperationClaimDto>> GetUsersClaimsById(int userId);
    }
}
