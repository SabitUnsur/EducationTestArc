using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Languages.ValidationRules
{
    public class QuizContentValidator : AbstractValidator<QuizContent>
    {
        public QuizContentValidator()
        {
            RuleFor(q => q.Answer).NotEmpty();
            RuleFor(q => q.Id).GreaterThanOrEqualTo(1);
            RuleFor(q => q.CourseId).GreaterThanOrEqualTo(1);
            RuleFor(q => q.Answer).MinimumLength(1);
            RuleFor(q => q.Question).NotEmpty();
            RuleFor(q => q.Question).MinimumLength(1);
        }
    }
}
