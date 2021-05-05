using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;

namespace Business.Concrate
{
    public class WalletManager : IWalletService
    {
        private IWalletDal _walletDal;

        public WalletManager(IWalletDal walletDal)
        {
            _walletDal = walletDal;
        }

        public IDataResult<List<Wallet>> GetAll()
        {
            return new SuccessDataResult<List<Wallet>>(_walletDal.GetAll());
        }

        public IDataResult<Wallet> GetById(int walletId)
        {
            return new SuccessDataResult<Wallet>(_walletDal.Get(w => w.Id == walletId));
        }

        public IResult Add(Wallet wallet)
        {
            _walletDal.Add(wallet);
            return new SuccessResult(message: "Wallet Created");
        }

        public IResult Delete(Wallet wallet)
        {
            _walletDal.Delete(wallet);
            return new SuccessResult(message: "Wallet Deleted");
        }

        public IResult Update(Wallet wallet)
        {
            _walletDal.Update(wallet);
            return new SuccessResult(message: "Wallet Updated");
        }

        public IResult VerifyWallet(Wallet wallet)
        {
            wallet.ToVerify = true;
            _walletDal.Update(wallet);
            return new SuccessResult("Wallet Verified");
        }
    }
}
