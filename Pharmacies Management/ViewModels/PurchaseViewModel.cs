using PharmaciesManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PharmaciesManagement.ViewModels
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        [Display(Name = "التاريخ")]
        public DateTime Date { get; set; }
        [Display(Name = "الفرع")]
        public int StoreId { get; set; }
        public IEnumerable<Store> Stores { get; set; }

        [Display(Name = "المنتج")]
        public int ItemId { get; set; }
        public IEnumerable<Item> Items { get; set; }

        [Display(Name = "الكمية")]
        public int Quantity { get; set; }
    }
}
