using CodeChallenge.Core.DTOs;
using FluentValidation;

namespace CodeChallenge.Core.Validators
{
    public class ValidatorProductDTO : AbstractValidator<ProductDTO>
    {
        public ValidatorProductDTO()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(50);
            RuleFor(p => p.Description).MaximumLength(50);
            RuleFor(p => p.AgeRestriction).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
            RuleFor(p => p.Company_Id).NotNull().NotEmpty();
            RuleFor(p => p.Price).Must(it => it >= 1 && it <= 1000);
        }
    }
}
