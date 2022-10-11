using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Languages.ValidationRules
{
    public class InstructorValidator : AbstractValidator<Instructor>
    {
        public InstructorValidator()
        {
            RuleFor(i => i.UserId).GreaterThanOrEqualTo(1);
            RuleFor(i => i.UserId).NotEmpty();
            RuleFor(i => i.Id).NotEmpty();

        }
    }
}
