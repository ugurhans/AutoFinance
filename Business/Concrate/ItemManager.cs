using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;

namespace Business.Concrate
{
    public class ItemManager : IItemService
    {
        private IItemDal _itemDal;

        public ItemManager(IItemDal itemDal)
        {
            _itemDal = itemDal;
        }

        public IDataResult<List<Item>> GetAll()
        {
            return new SuccessDataResult<List<Item>>(_itemDal.GetAll());
        }

        public IDataResult<Item> GetById(int itemId)
        {
            return new SuccessDataResult<Item>(_itemDal.Get(i => i.Id == itemId));
        }

        public IResult Add(Item item)
        {
            _itemDal.Add(item);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Item item)
        {
            _itemDal.Delete(item);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IResult Update(Item item)
        {
            _itemDal.Update(item);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
