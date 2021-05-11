using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Entities.Concrate;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrate
{
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }
    }
}
