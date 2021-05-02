using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrate.EntityFrameWork;


namespace DataAccess.Concrate.EntityFramework
{
    public class EfWalletDal : EfEntityRepositoryBase<Wallet, AutoFinanceContext>, IWalletDal
    {
    }
}
