using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrate;

namespace Business.Abstract
{
    public interface IWalletService
    {
        IDataResult<List<Wallet>> GetAll();
        IDataResult<Wallet> GetById(int walletId);
        IResult Add(Wallet wallet);
        IResult Delete(Wallet wallet);
        IResult Update(Wallet wallet);

        IResult VerifyWallet(Wallet wallet);
    }
}
