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
        public List<WalletDto> getAllWalletDtos(Expression<Func<WalletDto, bool>> filter = null)
        {
            using (AutoFinanceContext context = new AutoFinanceContext())
            {
                var result = from w in context.Wallets
                             join u in context.Users
                                 on w.UserId equals u.Id
                             select new WalletDto()
                             {
                                 UserName = u.Name,
                                 UserLastName = u.LastName,
                                 Balance = w.Balance,
                                 ToVerify = w.ToVerify
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
