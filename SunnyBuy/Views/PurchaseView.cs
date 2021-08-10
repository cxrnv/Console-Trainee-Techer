using System;
using SunnyBuy.Services.UsersServices;
using SunnyBuy.Services.UsersServices.Models;

namespace SunnyBuy.Views
{
    public class PurchaseView
    {
        CartView cartView = new CartView();
        HomeView homeView = new HomeView();
        ClientService userService = new ClientService();
        ProductsView productsView = new ProductsView();

        public void PurchaseRegisterView()
        {
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       -----------------------------------------    Payment Type   ---------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            Console.WriteLine("           Payment types: \n" +
                "                         (1) CreditCard \n" +
                "                         (2) Billet \n" +
                "                         (3) Pix");

            Console.WriteLine();
            Console.Write("           Choose the payment type: ");
            var payment = Console.ReadLine();
            Console.WriteLine();

            Console.Write("           Confirm purchase ? y/n ");
            var confirm_purchase = Console.ReadLine();

            switch (confirm_purchase)
            {
                case "y":
                    Console.Clear();
                    PurchaseCompleteNav();

                    switch (payment)
                    {
                        case "1":
                            CreditCardView();
                            break;
                        case "2":
                            Console.Clear();
                            BilletView();
                            break;
                        case "3":
                            Console.Clear();
                            PixView();
                            break;
                        default:
                            break;
                    }

                    switch (payment)
                    {
                        case "1":
                            payment = " (Credit Card)";
                            Console.WriteLine($" ");
                            break;
                        case "2":
                            payment = "(Billet)";
                            break;
                        case "3":
                            payment = "(Pix)";
                            break;
                        default:
                            break;
                    }

                    PurchaseCompleteNav();
                    Console.Write("       * Type your cpf: ");
                    var cpf = Console.ReadLine();
                    Console.WriteLine("       ---------------------------------------------------------------------------------------------------");

                    var userr = userService.GetClients(cpf);

                    userr.ForEach
                        (                            
                          u =>
                          Console.WriteLine
                          ($"        {u.Name}\n \n" +
                           $"        {u.Email}\n \n" +
                           $"        {u.Phone}\n \n" +
                           $"        Send to: {u.Address}\n")
                        );
                    Console.WriteLine($"        Payment Type: {payment}\n");
                    Console.WriteLine("       ___________________________________________________________________________________________________\n");
                    Console.WriteLine();

                    cartView.ProductsCart();

                    GoHome();
                    break;
                case "n":
                    cartView.ShowCart();
                    break;
                default:
                    cartView.ShowCart();
                    break;
            }
        }

        public void GoHome()
        {
            Console.Write("                                          Go to the home page ? y/n ");
            var awnserHome = Console.ReadLine().ToUpper();

            switch (awnserHome)
            {
                case "Y":
                    Console.Clear();
                    homeView.ShowHome();
                    Console.WriteLine("");
                    productsView.ProductsPageView();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("                                          Thanks for buying in SunnyBuy :) ");
                    Environment.Exit(0);
                    break;
            }
        }

        public void CreditCardView()
        {
            CreditCardModel model = new CreditCardModel();

            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       ---------------------------------------    Add Credit Card  --------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");
            Console.Write("       Card number *");
            model.Number = Console.ReadLine();
            Console.WriteLine("       ___________________________________________________________________________________________________");

            Console.Write("       Expiry (MM/YY) *");
            model.Expiry = Console.ReadLine();
            Console.WriteLine("       ___________________________________________________________________________________________________");

            Console.Write("       Card code *");
            model.Code = Console.ReadLine();
            Console.WriteLine("       ___________________________________________________________________________________________________");

            Console.Write("                                               Confirm payment ? y/n ");
            var a = Console.ReadLine().ToUpper();

            while (a != "Y")
            {
                Console.Write("                                           *Confirm payment ? y/n ");
                a = Console.ReadLine();
            }

            Console.Clear();
        }

        public void BilletView()
        {
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       -------------------------------------------    Billet  -------------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");
            Console.WriteLine();
            Random code = new Random();
            int billetCode = code.Next(999999999);
            Console.WriteLine($"       +                Billet Code: |||||||||||||| {billetCode} {billetCode} ||||||||||||||");
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();

            Console.Write("                                               Confirm payment ? y/n ");
            var a = Console.ReadLine().ToUpper();

            while (a != "Y")
            {
                Console.Write("                                           *Confirm payment ? y/n");
                a = Console.ReadLine();
            }

            Console.Clear();
        }

        public void PixView()
        {
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       -------------------------------------------    Pix  -------------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");
            Console.WriteLine();
            Random code = new Random();
            int pixCode = code.Next(999999999);
            Console.WriteLine($"       +                Billet Code: {pixCode} 416997954 316515200 786516544");
            Console.WriteLine();
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            Console.Write("                                               Confirm payment ? y/n ");
            var a = Console.ReadLine().ToUpper();

            while (a != "Y")
            {
                Console.Write("                                           *Confirm payment ? y/n ");
                a = Console.ReadLine();
            }

            Console.Clear();
        }

        public void PurchaseCompleteNav()
        {
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       ---------------------------------------    Purchase Complete  -------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");
        }
    }
}