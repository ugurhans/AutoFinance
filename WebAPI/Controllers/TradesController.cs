using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using Business.Constants;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TradesController : ControllerBase
    {
        private ITradeService _tradeService;
        private IProductService _productService;
        private IOrderService _orderService;
        private IWalletService _walletService;

        public TradesController(ITradeService tradeService, IOrderService orderService, IProductService productService, IWalletService walletService)
        {
            _tradeService = tradeService;
            _orderService = orderService;
            _productService = productService;
            _walletService = walletService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _tradeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int tradeId)
        {
            var result = _tradeService.GetById(tradeId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallDetails")]
        public IActionResult GetAllDetails()
        {
            var result = _tradeService.GetTradeDto();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPost("addtrade")]
        public IActionResult addTrade(Trade trade)
        {
            var result = _tradeService.Add(trade);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        public class TradeA
        {
            public int productId { get; set; }
            public int orderId { get; set; }
        }

        [HttpPost("addtradePro")]
        public IActionResult addTradePro([FromBody] TradeA a)
        {
            var taxPur = 0.25;
            decimal tradePrice = 0;

            var resultProduct = _productService.GetProductById(a.productId);

            Product product = resultProduct.Data;

            var resultOrder = _orderService.GetById(a.orderId);
            if (resultOrder.Data != null)
            {
                Order order = resultOrder.Data;
                var customerWallet = _walletService.GetByUserId(order.UserId).Data;
                var supplierWallet = _walletService.GetByUserId(product.SupplierId).Data;

                var tradeAmount = product.StockAmount >= order.OrderAmount ? order.OrderAmount : product.StockAmount;
                if (product.Price >= order.OrderPrice)
                {
                    tradePrice = order.OrderPrice * order.OrderAmount;
                }
                var trade = new Trade()
                {
                    ProductName = product.Name,
                    CustomerId = order.UserId,
                    SellDate = DateTime.Now,
                    SupplierId = product.SupplierId,
                    TradeAmount = tradeAmount,
                    TradePrice = tradePrice,
                    Tax = taxPur * tradeAmount * (double)tradePrice
                };

                var tax = taxPur * (double)trade.TradePrice;
                if (customerWallet.Balance >= trade.TradePrice && order.OrderPrice <= product.Price)
                {
                    var result = _tradeService.Add(trade);

                    customerWallet.Balance -= trade.TradePrice;
                    _walletService.Update(customerWallet);

                    supplierWallet.Balance += trade.TradePrice;
                    _walletService.Update(supplierWallet);

                    if (tradeAmount > product.StockAmount)
                    {
                        order.OrderAmount -= tradeAmount;
                        _orderService.Update(order);
                        _productService.Delete(product);
                    }

                    else if (order.OrderAmount < product.StockAmount)
                    {
                        product.StockAmount -= tradeAmount;
                        _productService.Update(product);
                        _orderService.Delete(order);
                    }

                    else
                    {
                        _productService.Delete(product);
                        _orderService.Delete(order);
                    }

                    return Ok(result);
                }
            }

            return BadRequest();
        }


        [HttpPost("deletetrade")]
        public IActionResult addeleteTrade(Trade trade)
        {
            var result = _tradeService.Delete(trade);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("updateTrade")]
        public IActionResult updateTrade(Trade trade)
        {
            var result = _tradeService.Update(trade);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
