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
    public class EfTradeDal : EfEntityRepositoryBase<Trade, AutoFinanceContext>, ITradeDal
    {
        public List<TradeDto> GetTradeDtos(Expression<Func<TradeDto, bool>> filter = null)
        {
            using (AutoFinanceContext context = new AutoFinanceContext())
            {
                var result = from t in context.Trades
                             join o in context.Orders
                                 on t.OrderId equals o.Id
                             join p in context.Products
                                 on t.ProductId equals p.Id
                             join u in context.Users
                                 on t.CustomerId equals u.Id
                             join us in context.Users
                                 on t.SupplierId equals us.Id
                             select new TradeDto
                             {
                                 SupplierName = us.Name + " " + us.LastName,
                                 CustomerName = u.Name + "" + us.LastName,
                                 ProductName = p.Name,
                                 SellDate = t.SellDate,
                                 TradeAmount = o.OrderAmount,
                                 TradePrice = o.Price
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

    }
}
