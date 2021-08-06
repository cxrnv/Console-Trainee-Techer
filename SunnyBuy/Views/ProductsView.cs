using System;
using SunnyBuy.Services.ProductsServices;

namespace SunnyBuy.Views
{
    public class ProductsView
    {
        HomeView homeView = new HomeView();
        LoginView loginView = new LoginView();
        SignUpView signUpView = new SignUpView();
        AssistenceView assistenceView = new AssistenceView();
        ProductsService productsservice = new ProductsService();

        public void ProductsPageView()
        {
            Console.WriteLine(
                "                                          (1) Choose a category \n \n" +
                "                                          (2) Go to the Cart \n \n" +
                "                                          (3) Login \n \n" +
                "                                          (4) Sign Up \n \n" +
                "                                          (5) Assistence"
                );
            Console.WriteLine("                                          ____________________\n");
            Console.Write($"                                           Choose a option: ");
            var page_option = Convert.ToInt32(Console.ReadLine());

            switch (page_option)
            {
                case 1:
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
                case 2:
                    CartView goToCart = new CartView();
                    Console.Clear();
                    goToCart.ShowCart();
                    break;
                case 3:
                    Console.Clear();
                    loginView.ShowLoginView();
                    break;
                case 4:
                    Console.Clear();
                    signUpView.ShowSignUpView();
                    break;
                case 5:
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
                            ProductsPageView();
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
                    ProductsPageView();
                    break;
            }
        }
    }
}