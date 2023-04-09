using FluentValidation;
using PharmaciesManagement.ViewModels;

namespace Pharmacies_Management.Validators
{
    public class ItemViewModelValidator : AbstractValidator<ItemViewModel>
    {
        public ItemViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull()
                .WithMessage("إسم الصنف مطلوب")
                .MinimumLength(3)
                .WithMessage("يجب إدخال 3 حروف على الأقل");
        }
    }
}
