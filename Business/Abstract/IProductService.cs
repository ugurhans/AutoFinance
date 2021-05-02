using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetById(int itemId);
        IResult Add(Product item);
        IResult Delete(Product item);
        IResult Update(Product item);

        IDataResult<List<ProductDetailDto>> GetProductsDetail();
        IDataResult<List<ProductDetailDto>> GetProductDetail(int productId);
        IDataResult<List<ProductDetailDto>> GetProductsDetailByCategory(int categoryId);
        IDataResult<List<ProductDetailDto>> GetProductsDetailBySupplier();
        IDataResult<List<ProductDetailDto>> GetProductsDetailBySupplierId(int supplierId);
    }
}
