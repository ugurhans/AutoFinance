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
                             join cus in context.Users
                                 on t.CustomerId equals cus.Id
                             join sus in context.Users
                                 on t.SupplierId equals sus.Id


                             select new TradeDto
                             {
                                 SupplierName = sus.Name + " " + sus.LastName,
                                 CustomerName = cus.Name + " " + cus.LastName,
                                 ProductName = t.ProductName,
                                 SellDate = t.SellDate,
                                 TradeAmount = t.TradeAmount,
                                 TradePrice = t.TradePrice
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

    }
}
