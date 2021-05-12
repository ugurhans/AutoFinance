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
    public class WalletsController : ControllerBase
    {
        private IWalletService _walletService;

        public WalletsController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _walletService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _walletService.GetAllDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalldetailsbyUserId")]
        public IActionResult GetAllDetailsByName(int userId)
        {
            var result = _walletService.GetAllDetailsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallById")]
        public IActionResult GetAllById(int walletId)
        {
            var result = _walletService.GetById(walletId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addwallet")]
        public IActionResult addWallet(Wallet wallet)
        {
            var result = _walletService.Add(wallet);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("updatewallet")]
        public IActionResult updateWallet(Wallet wallet)
        {
            var result = _walletService.Update(wallet);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("verifywallet")]
        public IActionResult berifyWallet(Wallet wallet)
        {
            var result = _walletService.VerifyWallet(wallet);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
