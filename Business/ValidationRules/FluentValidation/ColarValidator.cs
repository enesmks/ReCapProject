using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColarValidator : AbstractValidator<Colar>
    {
        public ColarValidator()
        {
            RuleFor(x => x.ColarName).MinimumLength(2).WithMessage(Messages.MinumumColarNameLength);
            RuleFor(X => X.ColarName).MaximumLength(30).WithMessage(Messages.MaximumColarNameLength);
            RuleFor(X => X.ColarName).NotEmpty().WithMessage(Messages.ColarNameCanNotBeEmpty);
        }
    }
}
