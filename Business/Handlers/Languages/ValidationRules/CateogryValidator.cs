using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Languages.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
            RuleFor(c => c.Id).GreaterThanOrEqualTo(1);

        }
    }
}
