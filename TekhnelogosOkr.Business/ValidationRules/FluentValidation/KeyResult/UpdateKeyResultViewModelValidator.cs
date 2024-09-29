using FluentValidation;
using TekhnelogosOkr.ViewModel.KeyResult;

namespace TekhnelogosOkr.Business.ValidationRules.FluentValidation.KeyResult
{
    public class UpdateKeyResultViewModelValidator : AbstractValidator<UpdateKeyResultViewModel>
    {
        public UpdateKeyResultViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .Length(1, 100).WithMessage("Başlık 1 ile 100 karakter arasında olmalıdır.");
        }
    }
}
