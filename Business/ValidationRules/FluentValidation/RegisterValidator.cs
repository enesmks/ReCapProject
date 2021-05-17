using Business.Constants;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage(Messages.PasswordCanBeNotEmpty);
            RuleFor(x => x.Password).MinimumLength(8).WithMessage(Messages.MinimumPasswordLength);
            RuleFor(x => x.Password).MaximumLength(16).WithMessage(Messages.MaximumPasswordLength);
            RuleFor(x => x.Password).Matches(@"[A-Z]+").WithMessage(Messages.PasswordMustContainUppercase);
            RuleFor(x => x.Password).Matches(@"[a-z]+").WithMessage(Messages.PasswordMustContainLowercase);
            RuleFor(x => x.Password).Matches(@"[0-9]+").WithMessage(Messages.PasswordMustContainNumber);

            RuleFor(x => x.Email).Must(EndWithHotmail).WithMessage(Messages.InvalidEmail);
            RuleFor(x => x.Email).Must(EndWithGemail).WithMessage(Messages.InvalidEmail);
            RuleFor(x => x.Email).Must(EndWithOutlook).WithMessage(Messages.InvalidEmail);
            RuleFor(x => x.Email).Must(EndWithYahoo).WithMessage(Messages.InvalidEmail);
        }

        private bool EndWithYahoo(string arg)
        {
            return arg.EndsWith("@yahoo.com");
        }

        private bool EndWithOutlook(string arg)
        {
            return arg.EndsWith("@outlook.com");
        }

        private bool EndWithGemail(string arg)
        {
            return arg.EndsWith("@gmail.com");
        }

        private bool EndWithHotmail(string arg)
        {
            return arg.EndsWith("@hotmail.com");
        }
    }
}
