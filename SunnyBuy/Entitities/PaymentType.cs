using SunnyBuy.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Entitities
{
    public class PaymentType
    {
        [Key]

        [Column("PaymentTypeId")]
        public PaymentTypeEnum PaymentTypeEnum { get; set; }
        public string Description { get; set; }
    }
}
