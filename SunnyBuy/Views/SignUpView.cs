using System;
using SunnyBuy.Services.UsersServices;
using SunnyBuy.Services.UsersServices.Models;

namespace SunnyBuy.Views
{
    public class SignUpView
    {
        HomeView homeView = new HomeView();
        LoginView loginView = new LoginView();
        public void ShowSignUpView()
        {
            ClientService userService = new ClientService();
            var user = new ListModel();

            Console.WriteLine("       ___________________________________________________________________________________________________\n");
            Console.WriteLine("       ------------------------------------------------  SignUp ------------------------------------------\n");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            Console.Write("       *           Cpf: ");
            user.Cpf = Console.ReadLine();

            while (user.Cpf.Length != 11)
            {
                Console.WriteLine("               Cpf number must have 11 characters: ");
                user.Cpf = Console.ReadLine();
            }

            Console.WriteLine();

            Console.Write("       *           Name: ");
            user.Name = Console.ReadLine();

            Console.WriteLine();

            Console.Write("       *           E mail: ");
            user.Email = Console.ReadLine();

            while (!user.EmailValidate(user.Email))
            {
                Console.WriteLine();
                Console.Write("       *           Type a valid email: ");
                user.Email = Console.ReadLine();
            }

            Console.WriteLine();

            Console.Write("       *           Type the address: ");
            user.Address = Console.ReadLine();
            Console.WriteLine();

            Console.Write("       *           Type the number phone: ");
            user.Phone = Console.ReadLine();

            while (user.Phone.Length != 9)
            {
                Console.WriteLine();
                Console.Write("       *           Phone number must have 9 characters: ");
                user.Phone = Console.ReadLine();
            }
            Console.WriteLine();

            userService.PostUser(user);

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
                            products.ProductsPageView();
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
