using System;

namespace SunnyBuy.Services.CreditCardServices.Models
{
    public class CreditCardListModel
    {
        public int CreditCardId { get; set; }
        public string Operator { get; set; }
        public string Number { get; set; }
        public string DueDate { get; set; }
        public string SecurityCode { get; set; }
        public int ClientId { get; set; }
    }
}
