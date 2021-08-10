namespace SunnyBuy.Services.UsersServices.Models
{
    public class SignUpModel
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public CreditCardModel CreditCard { get; set; }
    }
}