using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrate.EntityFrameWork;
using Entities.DTOs;


namespace DataAccess.Concrate.EntityFramework
{
    public class EfWalletDal : EfEntityRepositoryBase<Wallet, AutoFinanceContext>, IWalletDal
    {

        List<WalletDto> IWalletDal.getAllWalletDtos(Expression<Func<WalletDto, bool>> filter)
        {
            using (AutoFinanceContext context = new AutoFinanceContext())
            {
                var result = from w in context.Wallets
                             join u in context.Users
                                 on w.UserId equals u.Id
                             select new WalletDto()
                             {
                                 UserId = w.UserId,
                                 UserName = u.Name,
                                 UserLastName = u.LastName,
                                 Balance = w.Balance,
                                 ToVerify = w.ToVerify,
                                 WalletId = w.Id
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
