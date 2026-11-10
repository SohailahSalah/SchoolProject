using FluentValidation;
using SchoolProject.DTOs.School;

namespace SchoolProject.Validators
{
     public abstract class SchoolRequestValidator<T> : AbstractValidator<T>
        where T : SchoolRequestDTO
     {
        // protected لأن الكلاس abstract — الوارث بس اللي ينادي الـ constructor ده
        protected SchoolRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("School name is required.")
                .MinimumLength(2).WithMessage("School name must be at least 2 characters.")
                .MaximumLength(280).WithMessage("School  name cannot exceed 280 characters.")
                // Must = قاعدة مخصّصة: الاسم لازم يكون فيه حرف واحد على الأقل
                .Must(name => !string.IsNullOrWhiteSpace(name) && name.Any(char.IsLetter))
                .WithMessage("Company name must contain at least one letter.");

        }

     }
}

