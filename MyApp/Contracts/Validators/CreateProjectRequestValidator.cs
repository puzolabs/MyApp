using FluentValidation;
using MyApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Contracts.Validators
{
    public class CreateProjectRequestValidator : AbstractValidator<CreateProjectRequest>
    {
        public CreateProjectRequestValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                    .OnFailure(x => throw new MissingValueException(nameof(CreateProjectRequest.Name)));
        }
    }
}
