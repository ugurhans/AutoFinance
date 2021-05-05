﻿using System;
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
    public class EfUserDal : EfEntityRepositoryBase<User, AutoFinanceContext>, IUserDal
    {
        public List<UserDto> getUserDtos(Expression<Func<UserDto, bool>> filter = null)
        {
            using (AutoFinanceContext context = new AutoFinanceContext())
            {
                var result = from u in context.Users
                             join w in context.Wallets
                                 on u.Id equals w.UserId

                             select new UserDto()
                             {
                                 Id = u.Id,
                                 Name = u.Name,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 Balance = w.Balance
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
