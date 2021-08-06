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

        public SignUpModel(int id, string name, string email, string cpf, string address, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
            Address = address;
            Phone = phone;
        }

        public SignUpModel()
        {
        }

        public bool EmailValidate(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
