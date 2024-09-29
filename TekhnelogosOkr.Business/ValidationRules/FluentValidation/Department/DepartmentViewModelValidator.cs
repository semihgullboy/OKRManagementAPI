using FluentValidation;
using TekhnelogosOkr.ViewModel.Department;

namespace TekhnelogosOkr.Business.ValidationRules.FluentValidation.Department
{
    public class DepartmentViewModelValidator : AbstractValidator<DepartmentViewModel>
    {
        public DepartmentViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad boş olamaz.")
                .Length(2, 100).WithMessage("Ad, 2 ile 100 karakter arasında olmalıdır.");
        }
    }
}