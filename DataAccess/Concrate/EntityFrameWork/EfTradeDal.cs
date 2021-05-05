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
                             join s in context.Suppliers
                                 on t.SupplierId equals s.Id
                             join c in context.Customers
                                 on t.CustomerId equals c.Id
                             join p in context.Products
                                 on t.ProductId equals p.Id
                             join u in context.Users
                                 on s.UserId equals u.Id
                             join us in context.Users
                                 on c.UserId equals us.Id
                             select new TradeDto()
                             {
                                 Id = t.Id,
                                 SupplierId = s.Id,
                                 CustomerId = c.Id,
                                 ProductId = p.Id,
                                 SellDate = t.SellDate,
                                 TradeAmount = t.TradeAmount,
                                 SupplierName = u.Name,
                                 CustomerName = us.Name,
                                 ProductName = p.Name


                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

    }
}
