using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Concrate
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;


        public OrderManager(IOrderDal orderDal, IProductDal productDal)
        {
            _orderDal = orderDal;

        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IDataResult<Order> GetById(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o => o.OrderId == orderId));
        }


        [ValidationAspect(typeof(OrderValidator))]
        public IResult Add(Order order)
        {
            if (ChechkName(order.OrderProductName, order.UserId))
            {
                _orderDal.Add(order);
                return new SuccessResult(Messages.OrderAdd);
            }

            return new ErrorResult("Ürün ismi daha önce eklenmiş");
        }

        private bool ChechkName(string orderOrderProductName, int orderUserId)
        {
            var result = _orderDal.Get(o => o.OrderProductName == orderOrderProductName && o.UserId == orderUserId);
            if (result != null)
            {
                return false;
            }

            return true;
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
            return new SuccessDataResult<List<OrderDto>>(_orderDal.GetOrderDetail(o => o.OrderId == userId));
        }

        IDataResult<List<Order>> IOrderService.GetOrderByUserIdOrder(int userId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.UserId == userId));
        }

        public IDataResult<Order> GetOrderByName(int userId, string orderName)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(o =>
                o.UserId == userId && o.OrderProductName.ToLower() == orderName.ToLower()));
        }

    }

}
