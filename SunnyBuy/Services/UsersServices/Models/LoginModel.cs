namespace SunnyBuy.Services.UsersServices.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

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
