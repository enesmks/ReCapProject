using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(x => x.RentDate).Must(CanNotBeforeToday).WithMessage(Messages.CanNotBeforeToday);
            RuleFor(x => x.RentDate).NotEmpty().WithMessage(Messages.RentDateCanNotBeEmpty);
        }

        private bool CanNotBeforeToday(DateTime arg)
        {
            if (arg.Date<DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
