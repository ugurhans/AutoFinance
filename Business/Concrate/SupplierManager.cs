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
    public class SupplierManager : ISupplierService
    {
        private ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }


        public IDataResult<List<Supplier>> GetAll()
        {
            return new SuccessDataResult<List<Supplier>>(_supplierDal.GetAll());
        }

        public IDataResult<Supplier> GetById(int supplierId)
        {
            return new SuccessDataResult<Supplier>(_supplierDal.Get(s => s.Id == supplierId));
        }

        public IResult Add(Supplier supplier)
        {
            _supplierDal.Add(supplier);
            return new SuccessResult(Messages.SupplierAdded);
        }

        public IResult Delete(Supplier supplier)
        {
            _supplierDal.Delete(supplier);
            return new SuccessResult(Messages.SupplierDeleted);
        }

        public IResult Update(Supplier supplier)
        {
            _supplierDal.Update(supplier);
            return new SuccessResult(Messages.SupplierUpdated);
        }

        public IDataResult<List<SupplierDto>> GetSuppliersDto()
        {
            return new SuccessDataResult<List<SupplierDto>>(_supplierDal.GetSuppliersDtos());
        }

        public IDataResult<List<SupplierDto>> GetSupplierDtoById(int supplierId)
        {
            return new SuccessDataResult<List<SupplierDto>>(_supplierDal.GetSuppliersDtos(s => s.Id == supplierId));
        }
    }
}
