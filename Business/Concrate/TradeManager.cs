using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Concrate
{
    public class TradeManager : ITradeService
    {
        private ITradeDal _tradeDal;

        public TradeManager(ITradeDal tradeDal)
        {
            _tradeDal = tradeDal;
        }

        [CacheAspect(15)]
        public IDataResult<List<Trade>> GetAll()
        {
            return new SuccessDataResult<List<Trade>>(_tradeDal.GetAll());
        }

        public IDataResult<Trade> GetById(int tradeId)
        {
            return new SuccessDataResult<Trade>(_tradeDal.Get(t => t.Id == tradeId));
        }


        [CacheAspect(15)]
        public IDataResult<List<TradeDto>> GetTradeDto()
        {
            return new SuccessDataResult<List<TradeDto>>(_tradeDal.GetTradeDtos());
        }



        public IDataResult<List<TradeDto>> GetTradeDtoById(int tradeId)
        {
            return new SuccessDataResult<List<TradeDto>>(_tradeDal.GetTradeDtos(t => t.Id == tradeId));
        }


        [ValidationAspect(typeof(TradeValidator))]
        [CacheRemoveAspect("ITradeService.Get")]
        public IResult Add(Trade trade)
        {
            _tradeDal.Add(trade);
            return new SuccessResult(Messages.TradeSuccess);
        }


        [CacheRemoveAspect("ITradeService.Get")]
        public IResult Delete(Trade trade)
        {
            _tradeDal.Add(trade);
            return new SuccessResult(Messages.TradeDeleted);
        }


        [ValidationAspect(typeof(TradeValidator))]
        [CacheRemoveAspect("ITradeService.Get")]
        public IResult Update(Trade trade)
        {
            _tradeDal.Add(trade);
            return new SuccessResult(Messages.TradeUpdated);
        }
    }
}
