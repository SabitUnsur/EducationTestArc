using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Languages.ValidationRules
{
    public class CourseValidator : AbstractValidator<Course>
    {

        public CourseValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.Price).GreaterThanOrEqualTo(0);
            RuleFor(c => c.ExpireDate).NotEmpty();
        }
    }
}
