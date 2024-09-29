using FluentValidation;

namespace TekhnelogosOkr.ViewModel.Suggestion
{
    public class AddSuggestionViewModelValidator : AbstractValidator<AddSuggestionViewModel>
    {
        public AddSuggestionViewModelValidator()
        {
            RuleFor(x => x.KeyResultId)
                .GreaterThan(0).WithMessage("KeyResultId 0 olamaz.");

            RuleFor(x => x.SenderId)
                .GreaterThan(0).WithMessage("SenderId 0 olamaz.");

            RuleFor(x => x.ReceiverIds)
                .NotEmpty().WithMessage("ReceiverIds boş olamaz.")
                .Must(x => x.All(id => id > 0)).WithMessage("Tüm ReceiverId'ler 0'dan büyük olmalıdır.");
        }
    }
}
