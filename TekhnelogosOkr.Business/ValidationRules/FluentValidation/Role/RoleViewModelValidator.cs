using FluentValidation;
using TekhnelogosOkr.ViewModel.Role;

namespace TekhnelogosOkr.Business.ValidationRules.FluentValidation.Role
{
    public class RoleViewModelValidator : AbstractValidator<RoleViewModel>
    {
        public RoleViewModelValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad boş olamaz.")
                .Length(2, 100).WithMessage("Ad, 2 ile 100 karakter arasında olmalıdır.");
        }
    }
}
