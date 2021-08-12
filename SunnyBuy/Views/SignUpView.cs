using System;
using SunnyBuy.LoggedIn;
using SunnyBuy.Services.UsersServices;
using SunnyBuy.Services.UsersServices.Models;

namespace SunnyBuy.Views
{
    public class SignUpView
    {
        HomeView homeView = new HomeView();
        LoginView loginView = new LoginView();
        ClientLoggedIn loggedInclient = new ClientLoggedIn();
        Context.Context context = new Context.Context();

        public void ShowSignUpView()
        {
            ClientService userService = new ClientService(context);
            var client = new ListModel();

            Console.WriteLine("       ___________________________________________________________________________________________________\n");
            Console.WriteLine("       ------------------------------------------------  SignUp ------------------------------------------\n");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            Console.Write("       *           Cpf: ");
            client.Cpf = Console.ReadLine();

            while (client.Cpf.Length != 11)
            {
                Console.WriteLine("               Cpf number must have 11 characters: ");
                client.Cpf = Console.ReadLine();
            }

            Console.WriteLine();

            Console.Write("       *           Name: ");
            client.Name = Console.ReadLine();

            Console.WriteLine();

            Console.Write("       *           E mail: ");
            client.Email = Console.ReadLine();

            while (!client.EmailValidate(client.Email))
            {
                Console.WriteLine();
                Console.Write("       *           Type a valid email: ");
                client.Email = Console.ReadLine();
            }

            Console.Write("       *           Password: ");
            client.Password = Console.ReadLine();

            Console.WriteLine();

            Console.Write("       *           Type the address: ");
            client.Address = Console.ReadLine();
            Console.WriteLine();

            Console.Write("       *           Type the number phone: ");
            client.Phone = Console.ReadLine();

            while (client.Phone.Length != 9)
            {
                Console.WriteLine();
                Console.Write("       *           Phone number must have 9 characters: ");
                client.Phone = Console.ReadLine();
            }
            Console.WriteLine();

            userService.PostUser(client);

            ShowLogInQuestion();
        }

        public void ShowLogInQuestion()
        {
            Console.Write("                   Log In ? y/n - ");
            var awnser = Console.ReadLine().ToLower();

            switch (awnser)
            {
                case "y":
                    Console.Clear();
                    loginView.ShowLoginView();
                    break;
                case "n":
                    Console.WriteLine();
                    Console.WriteLine("                   Go the home page ? y/n - \n");
                    var awnserHomePage = Console.ReadLine().ToLower();

                    switch (awnserHomePage)
                    {
                        case "y":
                            Console.Clear();
                            homeView.ShowHome();
                            var products = new ProductsView();
                            products.ProductsPageView(loggedInclient);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("                   Thanks for choosing SunnyBuy :)");
                            break;
                    }

                    break;
                default:
                    Console.Clear();
                    ShowLogInQuestion();
                    break;
            }
        }
    }
}
