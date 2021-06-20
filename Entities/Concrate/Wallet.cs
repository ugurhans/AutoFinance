using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrate
{
    public class Wallet : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public decimal BalanceUs { get; set; }
        public decimal BalanceFr { get; set; }
        public decimal BalanceEur { get; set; }
        public bool ToVerify { get; set; }
    }
}
