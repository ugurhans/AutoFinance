using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrate;
using Entities.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.WalletId).NotEmpty();
            RuleFor(u => u.Name).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);

        }
    }
}
