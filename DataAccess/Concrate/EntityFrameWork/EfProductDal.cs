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
                             join s in context.Suppliers
                                 on p.SupplierId equals s.Id
                             select new ProductDetailDto()
                             {
                                 Id = p.Id,
                                 CategoryName = c.CategoryName,
                                 Description = p.Description,
                                 Name = p.Name,
                                 Price = p.Price,
                                 StockAmount = p.StockAmount,
                                 CategoryId = p.CategoryId,
                                 SupplierId = p.SupplierId,
                                 SupplierName = (from u in context.Users where u.Id == s.UserId select u.Name).FirstOrDefault(),
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
