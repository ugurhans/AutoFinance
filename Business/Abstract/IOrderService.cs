using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<Order> GetById(int orderId);
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);

        IDataResult<List<OrderDto>> GetOrdersDto();
        IDataResult<List<OrderDto>> GetOrderDtoByUserId(int userId);

        IDataResult<Order> GetOrderByUserIdOrder(int userId);
    }
}
