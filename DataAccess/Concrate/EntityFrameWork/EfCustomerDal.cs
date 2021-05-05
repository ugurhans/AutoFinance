using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;

namespace DataAccess.Concrate.EntityFrameWork
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, AutoFinanceContext>, ICustomerDal
    {
        public List<CustomerDto> getCustomerDtos(Expression<Func<CustomerDto, bool>> filter = null)
        {
            using (AutoFinanceContext context = new AutoFinanceContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                                 on c.Id equals u.Id
                             join w in context.Wallets
                                 on u.Id equals w.UserId
                             select new CustomerDto()
                             {
                                 Id = c.Id,
                                 Name = u.Name,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 Balance = w.Balance

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}

