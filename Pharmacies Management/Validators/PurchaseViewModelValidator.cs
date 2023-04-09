using FluentValidation;
using PharmaciesManagement.ViewModels;

namespace Pharmacies_Management.Validators
{
    public class PurchaseViewModelValidator : AbstractValidator<PurchaseViewModel>
    {
        public PurchaseViewModelValidator()
        {
            RuleFor(x => x.StoreId).NotEmpty().WithMessage("إسم الفرع مطلوب");
            RuleFor(x => x.ItemId).NotEmpty().WithMessage("إسم الصنف مطلوب");
            RuleFor(x => x.Quantity).NotNull().WithMessage("الكمية مطلوبة").GreaterThan(0).WithMessage("الكمية يجب ان تكون أكبر من 0");
        }
    }
}
