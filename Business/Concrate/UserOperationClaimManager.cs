using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrate;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concrate
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            var result = BusinessRules.Run(CheckClaimExists(userOperationClaim));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult();
        }

        public IDataResult<List<UserOperationClaimDto>> GetUsersClaimsById(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(_userOperationClaimDal.GetUsersClaimsDto(oc => oc.UserId == userId));
        }

        public IResult CheckClaimExists(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimDal.GetAll(u => u.UserId == userOperationClaim.UserId);
            foreach (var item in result)
            {
                if (item.OperationClaimId == userOperationClaim.OperationClaimId)
                {
                    return new ErrorResult(Messages.ClaimAlreadyExists);
                }
            }
            return new SuccessResult();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userOperationClaimDal.GetClaims(user);
        }

    }
}
