using FluentValidation;
using TekhnelogosOkr.ViewModel.Authentication;

namespace TekhnelogosOkr.Business.ValidationRules.FluentValidation.Authentication
{
    public class UserLoginViewModelValidator : AbstractValidator<UserLoginViewModel>
    {
        public UserLoginViewModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş girilemez.")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş girilimez.");
        }
    }
}