using System.ComponentModel.DataAnnotations;

namespace PharmaciesManagement.ViewModels
{
    public class StoreViewModel
    {
        public int Id { get; set; }
        [Display(Name = "إسم الفرع")]
        public string Branch { get; set; }

    }
}
