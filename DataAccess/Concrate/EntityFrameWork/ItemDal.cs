using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;

namespace DataAccess.Concrate.EntityFrameWork
{
    public class ItemDal : EfEntityRepositoryBase<Item, AutoFinanceContext>, IItemDal
    {
    }
}
