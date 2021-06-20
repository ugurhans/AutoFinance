using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrate;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;
        private IProductService _productService;
        private ITradeService _tradeService;

        public OrdersController(IOrderService orderService, ITradeService tradeService, IProductService productService)
        {
            _orderService = orderService;
            _tradeService = tradeService;
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalldto")]
        public IActionResult GetAllDto()
        {
            var result = _orderService.GetOrdersDto();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalldtobyuserid")]
        public IActionResult GetAll(int userId)
        {
            var result = _orderService.GetOrderDtoByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult getById(int orderId)
        {
            var result = _orderService.GetById(orderId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyuserid")]
        public IActionResult getByUserId(int userId, string orderName)
        {
            var result = _orderService.GetOrderByName(userId, orderName);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addorder")]
        public IActionResult addOrder(Order order)
        {
            var result = _orderService.Add(order);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("updateorder")]
        public IActionResult updateOrder(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deleteorder")]
        public IActionResult deleteOrder(Order order)
        {
            var result = _orderService.Delete(order);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
