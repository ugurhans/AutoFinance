using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Concrate
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        [CacheAspect(10)]
        public IDataResult<List<Product>> GetAllProducts()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }


        [CacheAspect(10)]
        public IDataResult<Product> GetProductById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }


        [CacheAspect(10)]
        public IDataResult<List<Product>> GetAllProductByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
        }


        [CacheAspect(10)]
        public IDataResult<List<ProductDetailDto>> GetAllProductsDto()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        [CacheAspect(10)]
        public IDataResult<List<Product>> GetAllProductUnVerified()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ToVerify == false));
        }


        [CacheAspect(10)]
        public IDataResult<List<ProductDetailDto>> GetAllProductDtoUnVerified()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(p => p.ToVerify == false));
        }


        [CacheAspect(10)]
        public IDataResult<List<Product>> GetAllProductVerified()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ToVerify == true));
        }


        [CacheAspect(10)]
        public IDataResult<List<ProductDetailDto>> GetAllProductDtoVerified()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(p => p.ToVerify == true));
        }


        [CacheRemoveAspect("IProductService.Get")]
        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("supplier")]
        public IResult Add(Product product)
        {
            product.ToVerify = false;
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }


        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("admin,supplier")]
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }


        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("admin,supplier")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            product.ToVerify = false;
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }


        [SecuredOperation("admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult ToVerify(Product product)
        {
            product.ToVerify = true;
            _productDal.Update(product);
            return new SuccessResult(Messages.productVerified);
        }

        public IDataResult<List<ProductDetailDto>> GetAllProductsDtoBySId(int suplierId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(p => p.SupplierId == suplierId));
        }
    }
}
