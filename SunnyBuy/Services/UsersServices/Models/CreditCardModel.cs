namespace SunnyBuy.Services.UsersServices.Models
{
    public class CreditCardModel
    {
        public int UserId { get; set; }
        public string Number { get; set; }
        public string Expiry { get; set; }
        public string Code { get; set; }

        public CreditCardModel(string number, string expiry, string code)
        {
            Number = number;
            Expiry = expiry;
            Code = code;
        }

        public CreditCardModel()
        {
        }
    }
}
