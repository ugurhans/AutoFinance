using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Concrate
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IDataResult<Order> GetById(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.Id == orderId));
        }

        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.OrderAdd);
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult(Messages.OrderDelete);
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdate);
        }

        public IDataResult<List<OrderDto>> GetOrdersDto()
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.GetOrderDetail());

        }

        public IDataResult<List<OrderDto>> GetOrderDtoByUserId(int userId)
        {
            return new SuccessDataResult<List<OrderDto>>(_orderDal.GetOrderDetail(o => o.Id == userId));
        }
    }
}
