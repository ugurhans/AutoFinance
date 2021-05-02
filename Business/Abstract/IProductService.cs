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
        IDataResult<List<Product>> GetAllVerifed();
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);

        IResult Verify(Product product);

        IDataResult<List<ProductDetailDto>> GetProductsDetail();
        IDataResult<List<ProductDetailDto>> GetProductDetail(int productId);
        IDataResult<List<ProductDetailDto>> GetProductsDetailByCategory(int categoryId);
        IDataResult<List<ProductDetailDto>> GetProductsDetailBySupplierId(int supplierId);

        public bool ChechVerify(int productId);


    }
}
