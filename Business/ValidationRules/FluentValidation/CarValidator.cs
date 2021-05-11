using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.CarName).MinimumLength(2).WithMessage(Messages.MinumumCarNameLength);
            RuleFor(x => x.CarName).MaximumLength(10).WithMessage(Messages.MaximumCarNameLength);
            RuleFor(x => x.CarName).NotEmpty().WithMessage(Messages.CarNameCanNotBeEmpty);
            RuleFor(x => x.Description).NotEmpty().WithMessage(Messages.DescrpitionCanNotBeEmpty);
            RuleFor(x => x.DailyPrice).NotEmpty().WithMessage(Messages.DailyPriceCanNotBeEmpty);
        }
    }
}
