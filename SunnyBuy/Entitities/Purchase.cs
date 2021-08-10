using System;
using System.ComponentModel.DataAnnotations;

namespace SunnyBuy.Entitities
{
    public class Purchase
    {
        [Key]
        public int? PurchaseId { get; set; }
        public DateTime DatePurchase { get; set; }
    }
}
