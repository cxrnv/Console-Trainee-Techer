using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Entitities
{
    public class PaymentTypeEntitie
    {
        public int PaymentTypeId { get; set; }
        [ForeignKey("CreditCard")]
        public int CreditCardId { get; set; }
        public int Billet { get; set; }
        public int Pix { get; set; }
    }
}
