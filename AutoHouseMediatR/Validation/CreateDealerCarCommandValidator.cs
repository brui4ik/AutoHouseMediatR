using AutoHouseMediatR.Commands;
using FluentValidation;

namespace AutoHouseMediatR.Validation
{
    public class CreateDealerCarCommandValidator: AbstractValidator<CreateDealerCarCommand>
    {
        public CreateDealerCarCommandValidator()
        {
            RuleFor(_ => _.DealerId).NotEmpty();
            RuleFor(_ => _.FactoryId).NotEmpty();
        }
    }
}
