using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TradeValidator : AbstractValidator<Trade>
    {
        public TradeValidator()
        {
            RuleFor(t => t.OrderId).Equal(t => t.SupplierId);
            RuleFor(t => t.SellDate).NotEmpty();
            RuleFor(t => t.TradeAmount).GreaterThan(1);
            RuleFor(t => t.TradeAmount).NotEmpty();
            RuleFor(t => t.ProductId).NotEmpty();
            RuleFor(t => t.CustomerId).NotEmpty();
        }


    }
}
