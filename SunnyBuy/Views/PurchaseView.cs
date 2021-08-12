using System;
using SunnyBuy.LoggedIn;
using SunnyBuy.Services.CartServices;
using SunnyBuy.Services.UsersServices;
using SunnyBuy.Services.PurchaseServices;
using SunnyBuy.Services.PurchaseServices.Models;
using SunnyBuy.Services.CreditCardServices.Models;

namespace SunnyBuy.Views
{
    public class PurchaseView
    {
        HomeView homeView = new HomeView();
        ProductsView productsView = new ProductsView();
        CartService cartService = new CartService(context);
        ClientLoggedIn loggedInclient = new ClientLoggedIn();
        ClientService clientService = new ClientService(context);
        PurchaseService purchaseService = new PurchaseService(context);
        static readonly Context.Context context = new Context.Context();
        CreditCardService creditCardService = new CreditCardService(context);

        public void PurchaseRegisterView(int clientId)
        {
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       -----------------------------------------    Payment Type   ---------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            clientService.GetClientsId(clientId)
                .ForEach(a => Console.WriteLine($"       {a.Name} :) Now, choose the payment type !"));
            Console.WriteLine("       ----------------------------------------------------------------------------------------------------\n");

            Console.WriteLine("           Payment types: \n" +
                "                         (1) CreditCard \n" +
                "                         (2) Billet \n" +
                "                         (3) Pix \n \n");

            Console.Write("           Choose the payment type: ");
            var payment = Console.ReadLine();

            ChoosePaymentType(payment, clientId);

            Console.WriteLine();
        }

        public void CreditCardView(int clientId)
        {
            Console.Clear();

            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       ------------------------------------------    Credit Card  ----------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            clientService.GetClientsId(clientId)
                .ForEach(a =>
                    System.Console.WriteLine
                    (   $"       {a.Name}\n" +
                        $"       {a.Email}\n" +
                        $"       {a.Phone}\n" +
                        $""
                    )
                );
            Console.WriteLine("              Exisiting cards");
            clientService.ExistingCards(clientId)
                .ForEach(a=>
                Console.WriteLine
                (
                 $"       Operator:      *{a.Operator}\n" +
                 $"       Due Date:      *{a.DueDate}\n" +
                 $"       Security Code: *{a.SecurityCode}\n\n" +
                 $"       "
                    ));

            Console.WriteLine
                ("       (1) Select an existing card\n" +
                 "       (2) Add a new card");
            var awnser = Convert.ToInt32(Console.ReadLine());

            switch (awnser)
            {
                case 1:

                    break;
                case 2:
                    break;
                default:
                    Console.Clear();
                    CreditCardView(clientId);
                    break;
            }


            PurchaseListModel purchaseListModel = new PurchaseListModel();
            CreditCardListModel model = new CreditCardListModel();


            clientService.GetClientsId(clientId)
               .ForEach(a => Console.WriteLine($"       {a.Name} :) Add a new card !"));//or select and existing card

            model.ClientId = clientId;

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
            model.SecurityCode = Console.ReadLine();
            Console.WriteLine("       ___________________________________________________________________________________________________");

            Console.Write("                                               Confirm payment ? y/n ");
            var a = Console.ReadLine().ToUpper();
            


            while (a != "Y")
            {
                Console.Write("                                           *Confirm payment ? y/n ");
                a = Console.ReadLine();
            }

            purchaseListModel.DatePurchase = DateTime.Now;
            purchaseListModel.ClientId = clientId;
            purchaseListModel.PaymentTypeEnum = Enums.PaymentTypeEnum.CreditCard;
            purchaseListModel.CartId = 7;


            creditCardService.AddCreditCard(model);
            purchaseService.PostPurchase(purchaseListModel);

            Console.Clear();

            PurchaseCompleteNav(clientId);
        }

        public void BilletView(int clientId)
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
            PurchaseCompleteNav(clientId);
        }

        public void PixView(int clientId)
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
            PurchaseCompleteNav(clientId);
        }

        public void PurchaseCompleteNav(int clientId)
        {
            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       ---------------------------------------    Purchase Complete  -------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            cartService.ShowProductsCart(clientId)
                .ForEach
                (
                    c => Console.WriteLine
                        (
                        $" {c.Name} \n" +
                        $" {c.Price}\n"
                        )
                );
        }

        public void ChoosePaymentType(string choose, int clientid)
        {
            switch (choose)
            {
                case "1":
                    CreditCardView(clientid);
                    break;
                case "2":
                    Console.Clear();
                    BilletView(clientid);
                    break;
                case "3":
                    Console.Clear();
                    PixView(clientid);
                    break;
                default:
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