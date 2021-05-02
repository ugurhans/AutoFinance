using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Concrate
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal itemDal)
        {
            _productDal = itemDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<Product> GetById(int itemId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(i => i.Id == itemId));
        }

        public IResult Add(Product item)
        {
            _productDal.Add(item);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product item)
        {
            _productDal.Delete(item);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product item)
        {
            _productDal.Update(item);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail(int productId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(p => p.Id == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetailByCategory(int categoryId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(p => p.CategoryId == categoryId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetailBySupplier()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetailBySupplierId(int supplierId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(p => p.SupplierId == supplierId));
        }
    }
}
