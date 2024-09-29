using FluentValidation;

namespace TekhnelogosOkr.ViewModel.OkrObjectiveTransaction
{
    public class AddOkrObjectiveTransactionViewModelValidator : AbstractValidator<AddOkrObjectiveTransactionViewModel>
    {
        public AddOkrObjectiveTransactionViewModelValidator()
        {
            RuleFor(x => x.OkrObjectiveId)
                .NotEmpty().WithMessage("OKRObjectiveId zorunludur.")
                .GreaterThan(0).WithMessage("OKRObjectiveId 0'dan büyük olmalıdır.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("İçerik zorunludur.")
                .MaximumLength(500).WithMessage("İçerik en fazla 500 karakter olmalıdır.");

            RuleFor(x => x.UpdatedByUserId)
                .NotEmpty().WithMessage("Güncelleyen kullanıcının Id'si zorunludur.")
                .GreaterThan(0).WithMessage("Güncelleyen kullanıcının Id'si 0'dan büyük olmalıdır.");
        }
    }
}
