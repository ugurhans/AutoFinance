using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrate;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IOperationClaimService _operationClaimService;
        private IUserOperationClaimService _userOperationClaimService;
        public UsersController(IUserService userService, IOperationClaimService operationClaimService, IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
        }



        [HttpGet("getallusers")]
        public IActionResult getAllUsers()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getuserbymail")]
        public IActionResult getUserByMail(string email)
        {
            var result = _userService.GetByMailData(email);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("adduser")]
        public IActionResult addUser(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPost("deleteuser")]
        public IActionResult deleteUser(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("updateuser")]
        public IActionResult updateUser(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallusersdto")]
        public IActionResult getAllUsersDto()
        {
            var result = _userService.getAllUserDto();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getuserdtobymail")]
        public IActionResult getUserDtoByMail(string email)
        {
            var result = _userService.GetUserDtoByMail(email);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getclaimsdtobyid")]
        public IActionResult getClaimsDtoById(int userId)
        {
            var result = _userOperationClaimService.GetUsersClaimsById(userId);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }


        [HttpGet("getalloperationclaims")]
        public IActionResult GetAllOperationClaims()
        {
            var result = _operationClaimService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("adduseroperationclaims")]
        public IActionResult AddUserOperaitonClaim(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimService.Add(userOperationClaim);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
