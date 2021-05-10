using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WalletValidator : AbstractValidator<Wallet>
    {
        public WalletValidator()
        {
            RuleFor(w => w.UserId).NotEmpty();
        }
    }
}
