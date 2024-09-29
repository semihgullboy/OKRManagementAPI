using FluentValidation;
using TekhnelogosOkr.ViewModel.CompanyObjective;

namespace TekhnelogosOkr.Validators
{
    public class AddCompanyObjectiveViewModelValidator : AbstractValidator<AddCompanyObjectiveViewModel>
    {
        public AddCompanyObjectiveViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.");

            RuleFor(x => x.Weight)
                .GreaterThan(0).WithMessage("Ağırlık 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(100).WithMessage("Ağırlık 100'den küçük veya eşit olmalıdır.");
        }
    }
}