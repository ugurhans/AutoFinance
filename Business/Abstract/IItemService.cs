using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrate;

namespace Business.Abstract
{
    public interface IItemService
    {
        IDataResult<List<Item>> GetAll();
        IDataResult<Item> GetById(int itemId);
        IResult Add(Item item);
        IResult Delete(Item item);
        IResult Update(Item item);
    }
}
