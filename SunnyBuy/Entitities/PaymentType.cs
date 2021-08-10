using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Entitities
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        public int CreditCardId { get; set; }

        [ForeignKey("CreditCard")]
        public CreditCard CreditCard { get; set; }
        public int Billet { get; set; }
        public int Pix { get; set; }
    }
}
