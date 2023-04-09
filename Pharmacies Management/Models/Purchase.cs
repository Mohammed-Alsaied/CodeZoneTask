using System;

namespace PharmaciesManagement.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        public int? ItemId { get; set; }
        public Item Item { get; set; }
        public int? Quantity { get; set; }
    }
}
