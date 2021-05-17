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
            RuleFor(x => x.RentDate).NotEmpty().WithMessage(Messages.RentDateCanNotBeEmpty);
            RuleFor(x => x.RentDate).Must(CanNotBeBeforeToday).WithMessage(Messages.InvalidRentDate);
            RuleFor(x => x.ReturnDate).Must(CanNotBeBeforeToday).WithMessage(Messages.InvalidRentDate);
        }

        private bool CanNotBeBeforeToday(DateTime arg)
        {
            if (arg.Date<DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
