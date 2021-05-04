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
    public class TradesController : ControllerBase
    {
        private ITradeService _tradeService;

        public TradesController(ITradeService tradeService)
        {
            _tradeService = tradeService;
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

        [HttpGet("getallDetailsById")]
        public IActionResult GetAllDetailsById(int tradeId)
        {
            var result = _tradeService.GetTradeDtoById(tradeId);
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
