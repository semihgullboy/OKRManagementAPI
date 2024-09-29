using FluentValidation;
using TekhnelogosOkr.ViewModel.Objective;

namespace TekhnelogosOkr.Business.ValidationRules.FluentValidation.OkrObjective
{
    public class AddDepartmentOkrObjectiveViewModelValidator : AbstractValidator<AddDepartmentOkrObjectiveViewModel>
    {
        public AddDepartmentOkrObjectiveViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş geçilemez.");

            RuleFor(x => x.Weight)
                .GreaterThan(0).WithMessage("Ağırlık 0'dan büyük olmalıdır.");

            RuleFor(x => x.CompanyObjectiveId)
                .GreaterThan(0).WithMessage("Şirket hedefi ID'si 0'dan büyük olmalıdır.");

            RuleFor(x => x.CreatedByUserId)
                .GreaterThan(0).WithMessage("Oluşturan kullanıcı ID'si 0'dan büyük olmalıdır.");
        }
    }
}
