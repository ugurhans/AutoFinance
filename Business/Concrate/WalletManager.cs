﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Concrate
{
    public class WalletManager : IWalletService
    {
        private IWalletDal _walletDal;

        public WalletManager(IWalletDal walletDal)
        {
            _walletDal = walletDal;
        }


        [CacheAspect(10)]
        public IDataResult<List<Wallet>> GetAll()
        {
            return new SuccessDataResult<List<Wallet>>(_walletDal.GetAll());
        }


        public IDataResult<Wallet> GetById(int walletId)
        {
            return new SuccessDataResult<Wallet>(_walletDal.Get(w => w.Id == walletId));
        }


        [ValidationAspect(typeof(WalletValidator))]
        [CacheRemoveAspect("IWalletService.Get")]
        public IResult Add(Wallet wallet)
        {
            _walletDal.Add(wallet);
            return new SuccessResult(message: "Wallet Created");
        }


        [CacheRemoveAspect("IWalletService.Get")]
        public IResult Delete(Wallet wallet)
        {
            _walletDal.Delete(wallet);
            return new SuccessResult(message: "Wallet Deleted");
        }



        [ValidationAspect(typeof(WalletValidator))]
        [CacheRemoveAspect("IWalletService.Get")]
        public IResult Update(Wallet wallet)
        {
            _walletDal.Update(wallet);
            return new SuccessResult(message: "Wallet Updated");
        }

        public IDataResult<List<WalletDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<WalletDto>>(_walletDal.getAllWalletDtos());
        }

        public IDataResult<List<WalletDto>> GetAllDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<WalletDto>>(_walletDal.getAllWalletDtos(w => w.UserId == userId));

        }


        [ValidationAspect(typeof(WalletValidator))]
        [CacheRemoveAspect("IWalletService.Get")]
        public IResult VerifyWallet(Wallet wallet)
        {
            wallet.ToVerify = true;
            _walletDal.Update(wallet);
            return new SuccessResult("Wallet Verified");
        }

        public IDataResult<List<WalletDto>> GetVerifiedDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<WalletDto>>(_walletDal.getAllWalletDtos(w => w.ToVerify == true && w.UserId == userId));
        }

        public IDataResult<Wallet> GetByUserId(int userId)
        {
            return new SuccessDataResult<Wallet>(_walletDal.Get(w => w.UserId == userId));
        }
    }
}
