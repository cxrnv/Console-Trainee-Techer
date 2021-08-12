using System;
using System.IO;
using SunnyBuy.LoggedIn;
using SunnyBuy.Services.UsersServices;
using SunnyBuy.Services.UsersServices.Models;

namespace SunnyBuy.Views
{
    public class LoginView
    {
        public void ShowLoginView()
        {
            var login = new LoginModel();
            var loggedInclient = new ClientLoggedIn();

            Context.Context context = new Context.Context();
            ClientService clientService = new ClientService(context); 

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
                login.Email = Console.ReadLine();
            }

            Console.Write("       *           Password: ");
            login.Password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && login.Password.Length > 0)
                {
                    Console.Write("\b \b");
                    login.Password = login.Password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    login.Password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            Console.WriteLine();

            loggedInclient = clientService.LoggedIn(login);

            try
            {
                if (loggedInclient == null)
                {
                    Console.WriteLine("Email ou senha incorretos, tente novamente");
                    Console.WriteLine(" ***** Try again ");
                    Console.Clear();
                    ShowLoginView();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um Erro");
                Console.WriteLine(e);
            }

            Console.Clear();
            HomeView home = new HomeView();
            ProductsView products = new ProductsView();
            home.ShowHome();
            products.ProductsPageView(loggedInclient);            
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
