using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class WalletDto : IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public decimal Balance { get; set; }
        public decimal BalanceUs { get; set; }
        public decimal BalanceEUR { get; set; }
        public decimal BalanceFR { get; set; }
        public bool ToVerify { get; set; }
        public int WalletId { get; set; }
    }
}
