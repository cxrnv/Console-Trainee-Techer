using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Entitities
{
    public class CreditCardEntitie
    {
        [Key]
        public int CreditCardId { get; set; }
        public string Operator { get; set; }
        public int Number { get; set; }
        public DateTime DueDate { get; set; }
        public int SecurityCode { get; set; }

        [ForeignKey("UserCpf")]
        public int UserCpf { get; set; }
    }
}
