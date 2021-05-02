using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
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

        public IDataResult<List<Trade>> GetAll()
        {
            return new SuccessDataResult<List<Trade>>(_tradeDal.GetAll());
        }

        public IDataResult<Trade> GetById(int tradeId)
        {
            return new SuccessDataResult<Trade>(_tradeDal.Get(t => t.Id == tradeId));
        }

        public IResult Add(Trade trade)
        {
            _tradeDal.Add(trade);
            return new SuccessResult(Messages.TradeSuccess);
        }

        public IResult Delete(Trade trade)
        {
            _tradeDal.Add(trade);
            return new SuccessResult(Messages.TradeDeleted);
        }

        public IResult Update(Trade trade)
        {
            _tradeDal.Add(trade);
            return new SuccessResult(Messages.TradeUpdated);
        }

        public IDataResult<List<TradeDto>> GetTradeDto()
        {
            return new SuccessDataResult<List<TradeDto>>(_tradeDal.GetTradeDtos());
        }



        public IDataResult<List<TradeDto>> GetTradeDtoById(int tradeId)
        {
            return new SuccessDataResult<List<TradeDto>>(_tradeDal.GetTradeDtos(t => t.Id == tradeId));
        }
    }
}
