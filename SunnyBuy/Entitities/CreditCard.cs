using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Entitities
{
    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }
        public string Operator { get; set; }
        public string Number { get; set; }
        public DateTime DueDate { get; set; }
        public int SecurityCode { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
    }
}
