using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrate;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<List<OperationClaim>> GetAll();
    }
}
