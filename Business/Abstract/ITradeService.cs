using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ITradeService
    {
        IDataResult<List<Trade>> GetAll();
        IDataResult<Trade> GetById(int tradeId);
        IResult Add(Trade trade);
        IResult Delete(Trade trade);
        IResult Update(Trade trade);

        IDataResult<List<TradeDto>> GetTradeDto();

    }
}
