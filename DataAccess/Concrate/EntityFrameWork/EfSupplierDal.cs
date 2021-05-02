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
    public class EfSupplierDal : EfEntityRepositoryBase<Supplier, AutoFinanceContext>, ISupplierDal
    {
        public List<SupplierDto> GetSuppliersDtos(Expression<Func<SupplierDto, bool>> filter = null)
        {
            using (AutoFinanceContext context = new AutoFinanceContext())
            {
                var result = from s in context.Suppliers
                             join u in context.Users
                                 on s.UserId equals u.Id

                             select new SupplierDto()
                             {
                                 Id = s.Id,
                                 Name = u.Name,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 Wallet = u.Wallet,

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
