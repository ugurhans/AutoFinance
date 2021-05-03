using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
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


        public IDataResult<List<Product>> GetAllProducts()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<Product> GetProductById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        public IDataResult<List<Product>> GetAllProductByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
        }

        public IDataResult<List<ProductDetailDto>> GetAllProductsDto()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<Product>> GetAllProductUnVerified()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ToVerify == false));
        }

        public IDataResult<List<ProductDetailDto>> GetAllProductDtoUnVerified()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(p => p.ToVerify == false));
        }

        public IDataResult<List<Product>> GetAllProductVerified()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ToVerify == true));
        }

        public IDataResult<List<ProductDetailDto>> GetAllProductDtoVerified()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(p => p.ToVerify == true));
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult ToVerify(Product product)
        {
            product.ToVerify = true;
            _productDal.Update(product);
            return new SuccessResult(Messages.productVerified);
        }
    }
}
