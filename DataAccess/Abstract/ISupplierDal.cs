using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrate;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ISupplierDal : IEntityRepository<Supplier>
    {
        List<SupplierDto> GetSuppliersDtos(Expression<Func<SupplierDto, bool>> filter = null);
    }
}
