using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspect;
using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {

        IDataResult<List<Product>> GetAllProducts();
        IDataResult<Product> GetProductById(int productId);
        IDataResult<List<Product>> GetAllProductByCategoryId(int categoryId);
        IDataResult<List<ProductDetailDto>> GetAllProductsDto();
        IDataResult<List<Product>> GetAllProductUnVerified();
        IDataResult<List<ProductDetailDto>> GetAllProductDtoUnVerified();
        IDataResult<List<Product>> GetAllProductVerified();
        IDataResult<List<ProductDetailDto>> GetAllProductDtoVerified();

        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IResult ToVerify(Product product);

        IDataResult<List<Product>> CheckProducts(string orderName);
    }
}
