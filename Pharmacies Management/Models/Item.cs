using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmaciesManagement.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }
    }
}
