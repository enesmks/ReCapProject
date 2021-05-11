using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x=>x.CustomerName).MinimumLength(2).WithMessage(Messages.MinumumCustomerNameLength);
            RuleFor(X => X.CustomerName).MaximumLength(20).WithMessage(Messages.MaximumCustomerNameLength);
            RuleFor(X => X.CustomerName).NotEmpty().WithMessage(Messages.CustomerNameCanNotBeEmpty);
        }
    }
}
