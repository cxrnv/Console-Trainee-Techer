using System;
using SunnyBuy.LoggedIn;
using SunnyBuy.Services.UsersServices;
using SunnyBuy.Services.CreditCardServices.Models;
using SunnyBuy.Services.PurchaseServices;

namespace SunnyBuy.Views
{
    public class PurchaseView
    {
        HomeView homeView = new HomeView();
        CartView cartView = new CartView();
        ProductsView productsView = new ProductsView();
        ClientLoggedIn loggedInclient = new ClientLoggedIn();
        ClientService userService = new ClientService(context);
        PurchaseService purchaseService = new PurchaseService(context);
        static readonly Context.Context context = new Context.Context();
        CreditCardService creditCardService = new CreditCardService(context);

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
                            Console.WriteLine("Type your id: ");
                            var clientid = Convert.ToInt32(Console.ReadLine());

                            CreditCardView(clientid);
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

                    var userr = userService.GetClientsCpf(cpf);

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

                    Console.Write("       * Type your id: ");
                    var id = Convert.ToInt32(Console.ReadLine());
                    cartView.ProductsCart(id);

                    GoHome();
                    break;
                case "n":
                    Console.WriteLine("yess");
                    break;
                default:
                    Console.WriteLine("yess");
                    break;
            }
        }

        public void CreditCardView(int clientid)
        {
            ListModel model = new ListModel();

            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       ---------------------------------------    Add Credit Card  --------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            model.ClientId = clientid;

            Console.Write("       Operator:  *");
            model.Operator = Console.ReadLine();
            Console.WriteLine("       ___________________________________________________________________________________________________");

            Console.Write("       Card number *");
            model.Number = Console.ReadLine();
            Console.WriteLine("       ___________________________________________________________________________________________________");

            Console.Write("       Expiry (MM/YY) *");
            model.DueDate = Console.ReadLine();
            Console.WriteLine("       ___________________________________________________________________________________________________");

            Console.Write("       Card code *");
            model.SecurityCode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("       ___________________________________________________________________________________________________");

            Console.Write("                                               Confirm payment ? y/n ");
            var a = Console.ReadLine().ToUpper();
            

            while (a != "Y")
            {
                Console.Write("                                           *Confirm payment ? y/n ");
                a = Console.ReadLine();
            }

            creditCardService.AddCreditCard(model);

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

            purchaseService
                .ShowPurchase(5);
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
                    productsView.ProductsPageView(loggedInclient);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("                                          Thanks for buying in SunnyBuy :) ");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}