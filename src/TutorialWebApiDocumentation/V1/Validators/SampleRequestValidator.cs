using FluentValidation;
using TutorialWebApiDocumentation.V1.DTOs;

namespace TutorialWebApiDocumentation.V1.Validators
{
    public class SampleRequestValidator : AbstractValidator<SampleRequest>
    {
        public SampleRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                    .WithErrorCode("missing_field_value")
                    .WithMessage("The {Id} does not contain value")
                .GreaterThanOrEqualTo(1)
                    .WithErrorCode("bad_format")
                    .WithMessage("{Id} should have a value greatet than zero (0)");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithErrorCode("bad_format")
                .WithMessage("The {Name} should have a value with maximum length of 100");
        }
    }
}
