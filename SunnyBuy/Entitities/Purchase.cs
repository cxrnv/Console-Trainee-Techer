using SunnyBuy.Enums;
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

        [Column("PaymentTypeId")]
        public PaymentTypeEnum PaymentTypeEnum { get; set; }

        [ForeignKey(nameof(PaymentTypeEnum))]
        public PaymentType PaymentType { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
    }
}
