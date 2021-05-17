using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(x => x.CartNumber).NotEmpty().WithMessage(Messages.CardNumberCanNotBeEmpty);
            RuleFor(x => x.CartNumber).MinimumLength(16).WithMessage(Messages.InvalidCartNumber);
            RuleFor(x => x.CartNumber).MaximumLength(16).WithMessage(Messages.InvalidCartNumber);
            RuleFor(x => x.Cvv).NotEmpty().WithMessage(Messages.CvvCanNotBeEmpty);
            RuleFor(x => x.Cvv).MaximumLength(3).WithMessage(Messages.InvalidCvv);
            RuleFor(x => x.Cvv).MinimumLength(3).WithMessage(Messages.InvalidCvv);
            RuleFor(X => X.ExpMonth).NotEmpty().WithMessage(Messages.CreditCardDateCanNotBeEmty);
            RuleFor(x => x.ExpYear).NotEmpty().WithMessage(Messages.CreditCardDateCanNotBeEmty);
            RuleFor(x => x.CardType).NotEmpty().WithMessage(Messages.CardTypeCanotBeEmpty);
        }
    }
}
