using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrate;
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrate.EntityFrameWork
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, AutoFinanceContext>, IUserOperationClaimDal
    {
        public List<UserOperationClaimDto> GetUsersClaimsDto(Expression<Func<UserOperationClaimDto, bool>> filter = null)
        {
            using (AutoFinanceContext context = new AutoFinanceContext())
            {
                var result = from uo in context.UserOperationClaims
                             join oc in context.OperationClaims
                                 on uo.OperationClaimId equals oc.Id
                             select new UserOperationClaimDto()
                             {
                                 OperationClaimName = oc.Name,
                                 UserId = uo.UserId,

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }

        public List<OperationClaim> GetClaims(User user)
        {

            using (var context = new AutoFinanceContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }

        }
    }
}
