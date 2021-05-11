using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrate;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        List<OrderDto> GetOrderDetail(Expression<Func<OrderDto, bool>> filter = null);

    }
}
