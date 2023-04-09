using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaciesManagement.Models
{
    public class Store
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Branch { get; set; }
    }
}
