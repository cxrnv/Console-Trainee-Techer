using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Entitities
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public DateTime DatePurchase { get; set; }
        public int PaymentTypeId { get; set; }

        [ForeignKey(nameof(PaymentTypeId))]
        public PaymentType PaymentType { get; set; }
    }
}
