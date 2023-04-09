using FluentValidation;
using PharmaciesManagement.ViewModels;

namespace Pharmacies_Management.Validators
{
    public class StoreViewModelValidator : AbstractValidator<StoreViewModel>
    {
        public StoreViewModelValidator()
        {
            RuleFor(x => x.Branch).NotNull().WithMessage("إسم الفرع مطلوب").MinimumLength(4).WithMessage("يجب إدخال 4 حروف على الأقل");
        }
    }
}
