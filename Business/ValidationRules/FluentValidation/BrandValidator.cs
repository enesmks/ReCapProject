using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.BrandName).MinimumLength(2).WithMessage(Messages.MinumumBrandNameLength);
            RuleFor(X => X.BrandName).MaximumLength(20).WithMessage(Messages.MaximumBrandNameLength);
            RuleFor(X => X.BrandName).NotEmpty().WithMessage(Messages.BrandNameCanNotBeEmpty);
        }
    }
}
