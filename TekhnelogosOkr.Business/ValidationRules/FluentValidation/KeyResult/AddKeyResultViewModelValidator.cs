using FluentValidation;
using TekhnelogosOkr.ViewModel.KeyResult;

namespace TekhnelogosOkr.Business.ValidationRules.FluentValidation.KeyResult
{
    public class AddKeyResultViewModelValidator : AbstractValidator<AddKeyResultViewModel>
    {
        public AddKeyResultViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .Length(3, 100).WithMessage("Başlık 3 ile 100 karakter arasında olmalıdır.");

            RuleFor(x => x.TargetDate)
                .GreaterThan(DateTime.Now).WithMessage("Hedef tarih gelecekte olmalıdır.");

            RuleFor(x => x.CreatedByUserId)
                .GreaterThan(0).WithMessage("Oluşturan Kullanıcı ID'si pozitif bir tam sayı olmalıdır.");

            RuleFor(x => x.OkrObjectiveId)
                .GreaterThan(0).WithMessage("OKR Hedef ID'si pozitif bir tam sayı olmalıdır.");
        }
    }
}
