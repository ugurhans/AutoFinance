using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrate;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IWalletDal : IEntityRepository<Wallet>
    {
        List<WalletDto> getAllWalletDtos(Expression<Func<WalletDto, bool>> filter = null);
    }
}
