using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrate;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ITradeDal : IEntityRepository<Trade>
    {
        List<TradeDto> GetTradeDtos(Expression<Func<TradeDto, bool>> filter = null);
    }
}
