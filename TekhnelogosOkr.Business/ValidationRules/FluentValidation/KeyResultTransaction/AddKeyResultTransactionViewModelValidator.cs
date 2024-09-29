using FluentValidation;
using TekhnelogosOkr.ViewModel.KeyResultTransaction;

namespace TekhnelogosOkr.ViewModel.KeyResultTransaction
{
    public class AddKeyResultTransactionViewModelValidator : AbstractValidator<AddKeyResultTransactionViewModel>
    {
        public AddKeyResultTransactionViewModelValidator()
        {
            RuleFor(x => x.KeyResultId)
                .NotEmpty().WithMessage("KeyResultId zorunludur.")
                .GreaterThan(0).WithMessage("KeyResultId 0'dan büyük olmalıdır.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("İçerik zorunludur.")
                .MaximumLength(1000).WithMessage("İçerik en fazla 1000 karakter olmalıdır.");

            RuleFor(x => x.EndingRate)
                .NotEmpty().WithMessage("Bitiş Oranı zorunludur.")
                .InclusiveBetween(0, 100).WithMessage("Bitiş Oranı 0 ile 100 arasında olmalıdır.");

            RuleFor(x => x.UpdatedByUserId)
                .NotEmpty().When(x => x.UpdatedByUserId.HasValue).WithMessage("Güncellenen Kullanıcı Kimliği zorunludur.");            
        }
    }
}
