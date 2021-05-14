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
    public class EfProductDal : EfEntityRepositoryBase<Product, AutoFinanceContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using (AutoFinanceContext context = new AutoFinanceContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                                 on p.CategoryId equals c.Id
                             join u in context.Users
                                 on p.SupplierId equals u.Id
                             select new ProductDetailDto()
                             {
                                 ProductId = p.Id,
                                 Name = p.Name,
                                 CategoryName = c.CategoryName,
                                 Description = p.Description,
                                 Price = p.Price,
                                 StockAmount = p.StockAmount,
                                 SupplierName = u.Name + "" + u.LastName,
                                 ToVerify = p.ToVerify,
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
