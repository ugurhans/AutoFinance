using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Entities.Concrate;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        List<UserOperationClaimDto> GetUsersClaimsDto(Expression<Func<UserOperationClaimDto, bool>> filter = null);

        List<OperationClaim> GetClaims(User user);
    }
}
