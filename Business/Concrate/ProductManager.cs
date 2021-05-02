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


        public IDataResult<List<Product>> GetAllVerifed()
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.ToVerify == true));
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());

        }

        public IDataResult<Product> GetById(int productId)
        {
            if (ChechVerify(productId))
            {
                return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
            }



            return new ErrorDataResult<Product>();
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            Verify(product);
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

        public IResult Verify(Product product)
        {
            product.ToVerify = true;
            _productDal.Update(product);
            return new SuccessResult();
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail(int productId)
        {
            if (ChechVerify(productId))
            {
                return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(p => p.Id == productId));

            }

            return new ErrorDataResult<List<ProductDetailDto>>("Doğrulanmamış Ürün");
        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetailByCategory(int categoryId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(p => p.CategoryId == categoryId));
        }


        public IDataResult<List<ProductDetailDto>> GetProductsDetailBySupplierId(int supplierId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(
                _productDal.GetProductDetails(p => p.SupplierId == supplierId));
        }

        public bool ChechVerify(int productId)
        {
            bool verify = _productDal.Get(p => p.Id == productId).ToVerify;
            if (verify)
            {
                return true;
            }

            return false;
        }
    }
}
