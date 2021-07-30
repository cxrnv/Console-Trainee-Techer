using SunnyBuy.Entitities;
using SunnyBuy.Enums;
using SunnyBuy.Services.CartServices;
using SunnyBuy.Services.PurchaseServices;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SunnyBuy.Views
{
    public class PurchaseView
    {
        CartView cartView = new CartView();
        UserEntitie user = new UserEntitie();
        PaymentType payment = new PaymentType();
        CartService cartService = new CartService();
        Regex regex = new Regex(@"^[A-z][A-z|\.|\s]+$");
        PurchaseService purchaseService = new PurchaseService();
        public void PurchaseRegisterView()
        {
            Console.WriteLine("___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------    Purchase   ------------------------------------------");
            Console.WriteLine("___________________________________________________________________________________________________\n");
            Console.WriteLine("------------------------------------------ R E G I S T E R ----------------------------------------\n");
            Console.WriteLine("--------------------------------------------   U S E R  -------------------------------------------\n");

            Console.Write("*           Name: ");
            var name = Console.ReadLine();

            /*
            bool nameValidate()
            {
                bool valid = regex.IsMatch(tB_UserName.Text);

                string errorMessage = valid ? string.Empty : "Please enter valid name";

                errorProvider1.SetError(tB_UserName, errorMessage);

                return valid;
            }*/

            Console.WriteLine();

            Console.Write("*           E mail: ");
            var email = Console.ReadLine();

            bool emailValidate(string email)
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
            Console.WriteLine();

            Console.Write("*           Type the address: ");
            var address = Console.ReadLine();
            Console.WriteLine();

            Console.Write("*           Type the number phone: ");
            var phone = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("           Payment types: \n" +
                "                        (1) CreditCard \n" +
                "                        (2) Billet \n" +
                "                        (3) Pix");

            Console.WriteLine();
            Console.Write("           Choose the payment type: ");
            PaymentType payment = Enum.Parse<PaymentType>(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Confirm purchase ?");
            var confirm_purchase = Console.ReadLine();

            switch (confirm_purchase)
            {
                case "y":
                    Console.Clear();
                    PurchaseComplete();

                    if (emailValidate(email))
                    {
                        Console.WriteLine($"        { name}                              Payment type {payment}\n");
                        Console.WriteLine($"        {email}\n");
                        Console.WriteLine($"        {address}\n");

                        var cart = cartService.ShowProductsCart();
                        var total = cart.Sum(a => a.Price);

                        cart.ForEach
                         (
                         a =>
                             Console.WriteLine
                             (
                                 $"        {a.Name} " +
                                 $"        R${ a.Price}\n"
                             )
                         );
                        Console.WriteLine("       ------------------------------------------------------------------------------------------");
                        Console.WriteLine($"                                                                                    Total: R${total}");
                        Console.WriteLine("       ------------------------------------------------------------------------------------------");
                    }else
                    {
                        PurchaseRegisterView();
                    }
                    break;
                case "n":
                    cartView.ShowCart();
                    break;
            }

            
               purchaseService.User( name, email, address, phone, payment);
            
           
        }
        public void CreditCardView()
        {
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       ---------------------------------------    Purchase Complete  --------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");
        }

        public void Billet()
        {

        }

        public void PurchaseComplete()
        {
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       ---------------------------------------    Purchase Complete  -------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");
        }
    }
}
