using System;
using SunnyBuy.LoggedIn;
using SunnyBuy.Services.ProductsServices;

namespace SunnyBuy.Views
{
    public class ProductsView
    {
        ClientLoggedIn loggedInclient = new ClientLoggedIn();
        static Context.Context context = new Context.Context();
        HomeView homeView = new HomeView();
        ClientView clientView = new ClientView();
        LoginView loginView = new LoginView();
        SignUpView signUpView = new SignUpView();
        AssistenceView assistenceView = new AssistenceView();
        ProductsService productsservice = new ProductsService(context);

        public void ProductsPageView(ClientLoggedIn loggedInclient)
        {
            Console.WriteLine(
                "                                          (1) User page \n \n" +
                "                                          (2) Choose a category \n \n" +
                "                                          (3) Go to the Cart \n \n" +
                "                                          (4) Login \n \n" +
                "                                          (5) Sign Up \n \n" +
                "                                          (6) Assistence"
                );
            Console.WriteLine("                                          ____________________\n");
            Console.Write($"                                           Choose a option: ");
            var page_option = Convert.ToInt32(Console.ReadLine());

            switch (page_option)
            {
                case 1:
                    Console.Clear();
                    clientView.ShowNav();
                    break;
                case 2:
                    Console.Clear();
                    homeView.ShowNav();
                    Console.WriteLine("");
                    Console.WriteLine("                                            Choose a category       ");
                    Console.WriteLine("                                            -----------------");
                    Console.WriteLine("                                           | (1) Computers   |\n" +
                                      "                                           | (2) Notebooks   |\n" +
                                      "                                           | (3) Acessories  | \n" +
                                      "                                           | (4) Smartphones | \n" +
                                      "                                           | (5) Tablets     |\n" +
                                      "                                            -----------------");
                    Console.Write("                                               Category: ");

                  
                    var chooseCategory = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    productsservice.ChooseOptionsCategory(chooseCategory);
                    break;
                case 3:
                    CartView goToCart = new CartView();
                    Console.Clear();
                    goToCart.ShowCart(loggedInclient);
                    break;
                case 4:
                    Console.Clear();
                    loginView.ShowLoginView();
                    break;
                case 5:
                    Console.Clear();
                    signUpView.ShowSignUpView();
                    break;
                case 6:
                    Console.Clear();
                    assistenceView.Assistence();
                    Console.WriteLine();
                    Console.Write("                                             Go to home page ? y/n ");
                    var goHome = Console.ReadLine().ToLower();

                    switch (goHome)
                    {
                        case "y":
                            Console.Clear();
                            homeView.ShowHome();
                            Console.WriteLine();
                            ProductsPageView(loggedInclient);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("  __________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.WriteLine("  -----------------------------------   SunnyBuy Assistence --------------------------------");
                            Console.WriteLine("  __________________________________________________________________________________________ \n");
                            Console.WriteLine();
                            Console.WriteLine("  ------------------------------------------------------------------------------------------- \n");
                            Console.WriteLine("                                  Thanks for choosing SunnyBuy :) \n");
                            Console.WriteLine("  -------------------------------------------------------------------------------------------");
                            break;
                    }
                    break;
                default:
                    Console.Clear();
                    homeView.ShowHome();
                    Console.WriteLine();
                    ProductsPageView(loggedInclient);
                    break;
            }
        }
    }
}