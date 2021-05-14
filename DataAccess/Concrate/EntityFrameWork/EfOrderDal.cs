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
    public class EfOrderDal : EfEntityRepositoryBase<Order, AutoFinanceContext>, IOrderDal
    {
        public List<OrderDto> GetOrderDetail(Expression<Func<OrderDto, bool>> filter = null)
        {
            using (AutoFinanceContext context = new AutoFinanceContext())
            {
                var result = from o in context.Orders
                             join u in context.Users
                                 on o.UserId equals u.Id
                             select new OrderDto()
                             {
                                 CustomerName = u.Name + "" + u.LastName,
                                 OrderAmount = o.OrderAmount,
                                 OrderProductName = o.OrderProductName,

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
