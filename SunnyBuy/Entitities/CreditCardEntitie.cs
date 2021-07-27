using System;

namespace SunnyBuy.Entitities
{
    public class CreditCardEntitie
    {
        public int CreditCardId { get; set; }
        public string Operator { get; set; }
        public int Number { get; set; }
        public DateTime DueDate { get; set; }
        public int SecurityCode { get; set; }
    }
}
