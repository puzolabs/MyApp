using FluentValidation;
using MyApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Contracts.Validators
{
    public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(d => d.UserName)
                .NotEmpty()
                    .OnFailure(x => throw new MissingValueException(nameof(LoginUserRequest.UserName)));

            RuleFor(d => d.Password)
                .NotEmpty()
                    .OnFailure(x => throw new MissingValueException(nameof(LoginUserRequest.Password)));
        }
    }
}
