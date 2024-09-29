using FluentValidation;

namespace TekhnelogosOkr.ViewModel.User
{
    public class UpdateUserViewModelValidator : AbstractValidator<UpdateUserViewModel>
    {
        public UpdateUserViewModelValidator()
        {
            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("Aktiflik durumu belirtilmelidir.");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("RoleId zorunludur.")
                .GreaterThan(0).WithMessage("RoleId 0'dan büyük olmalıdır.");
        }
    }
}
