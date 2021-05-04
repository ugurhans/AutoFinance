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
    public class SuppliersController : ControllerBase
    {
        private ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _supplierService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult getById(int supplierId)
        {
            var result = _supplierService.GetById(supplierId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public IActionResult getAllDetails()
        {
            var result = _supplierService.GetSuppliersDto();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public IActionResult getAllDetailsById(int supplierId)
        {
            var result = _supplierService.GetSupplierDtoById(supplierId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("addsupplier")]
        public IActionResult addSupplier(Supplier supplier)
        {
            var result = _supplierService.Add(supplier);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("deletesuppliers")]
        public IActionResult deleteSupplier(Supplier supplier)
        {
            var result = _supplierService.Delete(supplier);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("updatesuppliers")]
        public IActionResult updateSupplier(Supplier supplier)
        {
            var result = _supplierService.Update(supplier);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
