using FluentValidation;
using TekhnelogosOkr.ViewModel.CompanyObjective;

namespace TekhnelogosOkr.Business.ValidationRules.FluentValidation
{
    public class UpdateCompanyObjectiveViewModelValidator : AbstractValidator<UpdateCompanyObjectiveViewModel>
    {
        public UpdateCompanyObjectiveViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık gerekli.");

            RuleFor(x => x.Weight)
                .GreaterThan(0).WithMessage("Ağırlık 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(100).WithMessage("Ağırlık 100'den küçük veya eşit olmalıdır.");
        }
    }
}