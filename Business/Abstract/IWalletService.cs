using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IWalletService
    {
        IDataResult<List<Wallet>> GetAll();
        IDataResult<Wallet> GetById(int walletId);
        IResult Add(Wallet wallet);
        IResult Delete(Wallet wallet);
        IResult Update(Wallet wallet);

        IDataResult<List<WalletDto>> GetAllDetails();
        IDataResult<List<WalletDto>> GetAllDetailsByUserId(int userId);

        IResult VerifyWallet(Wallet wallet);
    }
}
