using System.ComponentModel.DataAnnotations;

namespace PharmaciesManagement.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        [Display(Name = "إسم الصنف")]
        public string Name { get; set; }
    }
}
