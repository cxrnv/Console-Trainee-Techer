using System;
using SunnyBuy.LoggedIn;
using SunnyBuy.Services.UsersServices;
using SunnyBuy.Services.UsersServices.Models;

namespace SunnyBuy.Views
{
    public class LoginView
    {
        public void ShowLoginView()
        {
            var loggedInclient = new ClientLoggedIn();

            Context.Context context = new Context.Context();
            ClientService userService = new ClientService(context);

            var login = new LoginModel();

            Console.WriteLine("       ___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("       --------------------------------------------   Login  --------------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            Console.Write("       *           E mail: ");
            login.Email = Console.ReadLine();
            Console.WriteLine();
            
            while (!login.EmailValidate(login.Email))
            {
                Console.WriteLine();
                Console.Write("       *           Type a valid email: ");
                client.Email = Console.ReadLine();
            }

            if (userService.Login(login.Email))
            {
                var userP = new LoginModel();
                Console.Write("       *           Password: ");
                userP.Password = string.Empty;
                ConsoleKey key;

                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;

                    if (key == ConsoleKey.Backspace && userP.Password.Length > 0)
                    {
                        Console.Write("\b \b");
                        userP.Password = userP.Password[0..^1];
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Console.Write("*");
                        userP.Password += keyInfo.KeyChar;
                    }
                } while (key != ConsoleKey.Enter);

                loggedInclient = client;

                HomeView homeView = new HomeView();
                ProductsView productsView = new ProductsView();

                Console.Clear();
                homeView.ShowHome();
                productsView.ProductsPageView();
            }
            else
            {
                Console.WriteLine("                   This email doesnt exist. \n");
                SignUpQuestion();               
            }


        }

        public void SignUpQuestion()
        {
            SignUpView signUp = new SignUpView();

            Console.Write("                   Sign Up ? y/n ");
            var awnserSignUp = Console.ReadLine().ToLower();

            switch (awnserSignUp)
            {
                case "y":
                    Console.Clear();
                    signUp.ShowSignUpView();
                    break;
                case "n":
                    break;
                default:
                    break;
            }
        }
    }
}
