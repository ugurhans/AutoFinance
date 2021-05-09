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
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService itemService)
        {
            _productService = itemService;
        }

        [HttpGet("getallproducts")]
        public IActionResult getAllProducts()
        {
            var result = _productService.GetAllProducts();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getproductbyid")]
        public IActionResult getProductById(int productId)
        {
            var result = _productService.GetProductById(productId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallproductsbycategoryıd")]
        public IActionResult getAllProductsByCategoryId(int categoryId)
        {
            var result = _productService.GetAllProductByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallproductsdto")]
        public IActionResult getAllProductsDto()
        {
            var result = _productService.GetAllProductsDto();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallproductsdtobySupplierId")]
        public IActionResult getAllProductsDtoBySId(int supplierId)
        {
            var result = _productService.GetAllProductsDtoBySId(supplierId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallproductsunverified")]
        public IActionResult getAllProductsUnVerified()
        {
            var result = _productService.GetAllProductUnVerified();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getallproductdtounverified")]
        public IActionResult getAllProductsDtoUnVerified()
        {
            var result = _productService.GetAllProductDtoUnVerified();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallproductsverified")]
        public IActionResult getAllProductsVerified()
        {
            var result = _productService.GetAllProductVerified();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getallproductdtoverified")]
        public IActionResult getAllProductsDtoVerified()
        {
            var result = _productService.GetAllProductDtoVerified();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addproduct")]
        public IActionResult addProduct(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("deleteproduct")]
        public IActionResult deleteProduct(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("updateproduct")]
        public IActionResult updateProduct(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("verifyproduct")]
        public IActionResult verifyProduct(Product product)
        {
            var result = _productService.ToVerify(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
