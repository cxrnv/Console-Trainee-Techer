using System;

namespace SunnyBuy.Services.CreditCardServices.Models
{
    public class ListModel
    {
        public int CreditCardId { get; set; }
        public string Operator { get; set; }
        public string Number { get; set; }
        public DateTime DueDate { get; set; }
        public int SecurityCode { get; set; }
        public string ClientCpf { get; set; }
    }
}
