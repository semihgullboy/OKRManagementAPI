using FluentValidation;
using TekhnelogosOkr.ViewModel.Objective;

namespace TekhnelogosOkr.Business.ValidationRules.FluentValidation.OkrObjective
{
    public class UpdateDepartmentOkrObjectiveViewModelValidator : AbstractValidator<UpdateDepartmentOkrObjectiveViewModel>
    {
        public UpdateDepartmentOkrObjectiveViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş geçilemez.")
                .Length(1, 100).WithMessage("Başlık 1 ile 100 karakter arasında olmalıdır.");

            RuleFor(x => x.Weight)
                .GreaterThan(0).WithMessage("Ağırlık 0'dan büyük olmalıdır.");

            RuleFor(x => x.StatusId)
                .GreaterThan(0).WithMessage("Durum ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.CompanyObjectiveId)
                .GreaterThan(0).WithMessage("CompanyObjectiveId  0'dan büyük olmalıdır.");
        }
    }
}
