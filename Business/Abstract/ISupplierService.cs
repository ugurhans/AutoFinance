using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        IDataResult<List<Supplier>> GetAll();
        IDataResult<Supplier> GetById(int supplierId);
        IResult Add(Supplier supplier);
        IResult Delete(Supplier supplier);
        IResult Update(Supplier supplier);

        IDataResult<List<SupplierDto>> GetSuppliersDto();
        IDataResult<List<SupplierDto>> GetSupplierDtoById(int supplierId);

    }
}
