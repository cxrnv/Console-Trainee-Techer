using SunnyBuy.Services.ProductsServices;
using SunnyBuy.Enums;
using System;
using SunnyBuy.Services.CartServices;
using SunnyBuy.Services.UsersServices;

namespace SunnyBuy.Views
{
    public class ProductsView
    {
        UsersService usersService = new UsersService();
        HomeView homeView = new HomeView();
        ProductView productView = new ProductView();
        CartService cartService = new CartService();
        ProductsService productsservice = new ProductsService();
        public void ProductsCategoryView()
        {
            Console.WriteLine(
                       "                                          (1) Choose a category \n \n" +
                       "                                          (2) Go to the Cart"
                       );
            Console.WriteLine("                                          ____________________\n");
            Console.Write($"                                           Choose a option: ");
            var page_option = Convert.ToInt32(Console.ReadLine());

            switch (page_option)
            {
                case 1:
                    Console.Clear();
                    homeView.ShowHome();
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
                    CartView cartView = new CartView();
                    switch (chooseCategory)
                    {
                        case 1:
                            ProductView cardComputers = new ProductView();
                            cardComputers.CardProductCategory("Computers");

                            var computers = productsservice.ChooseProductsCategory(CategoryEnum.Computer);

                            var indexComputer = 0;

                            computers.ForEach(a =>
                            {
                                Console.WriteLine
                                (
                                $"            | ({indexComputer}) { a.Name} ------- R${a.Price}"
                                );
                                indexComputer++;
                            }
                            );

                            

                            Console.WriteLine();
                            Console.Write("            Select a product: ");
                            var computerIndex = Convert.ToInt32(Console.ReadLine());

                            productView.ShowProductCartView();

                            var computerId = computers[computerIndex].ProductId;

                            var computer = productsservice.GetProduct(computerId);

                            Console.WriteLine("  --------------------Computer-------------------");
                            Console.WriteLine($"   Name: {computer.Name}");
                            Console.WriteLine($"   Price: {computer.Price}");
                            Console.WriteLine($"   Detail: {computer.Detail}");
                            Console.WriteLine($"   Quantity: {computer.Quantity} \n" +
                                $"  __________________________________________________");
                            Console.WriteLine();
                            Console.Write("    Add to cart ? y/n: ");
                            var awnser_computer = char.Parse(Console.ReadLine());

                            Console.WriteLine();

                            if (awnser_computer == 'Y' || awnser_computer == 'y')
                            {
                                if (cartService.PostProductCart(computerId))
                                    Console.WriteLine("      Added with success!  ");
                                else
                                    throw new Exception("The product cannot be placed in the cart!!");

                                Console.WriteLine();
                                Console.Write("      Go to cart page ? y/n: ");
                                var awnserCart = char.Parse(Console.ReadLine());

                                if (awnserCart == 'Y' || awnserCart == 'y')
                                {
                                    Console.Clear();
                                    cartView.ShowCart();
                                }
                                else
                                {
                                    Console.Clear();
                                    homeView.ShowHome();
                                    Console.WriteLine();
                                    ProductsCategoryView();
                                }
                            }
                            else if (awnser_computer == 'N' || awnser_computer == 'n')
                            {
                                Console.WriteLine("Back to home");
                                Console.Clear();
                                homeView.ShowHome();
                            }
                            break;
                        case 2:
                            ProductView cardNotebooks = new ProductView();
                            cardNotebooks.CardProductCategory("Notebooks");

                            var notebooks = productsservice.ChooseProductsCategory(CategoryEnum.Notebook);

                            var indexNotebook = 0;

                            notebooks.ForEach(a =>
                            {
                                Console.WriteLine
                                (
                                $"            | ({indexNotebook}) { a.Name} - R${a.Price} \n"
                                );
                                indexNotebook++;
                            }
                            );

                            Console.WriteLine();
                            Console.Write("            Select the product: ");
                            var notebookIndex = Convert.ToInt32(Console.ReadLine());
                            productView.ShowProductCartView();
                            var notebookId = notebooks[notebookIndex].ProductId;

                            var notebook = productsservice.GetProduct(notebookId);

                            Console.WriteLine("  --------------------Notebook-------------------");
                            Console.WriteLine($"   Name: {notebook.Name}");
                            Console.WriteLine($"   Price: {notebook.Price}");
                            Console.WriteLine($"   Detail: {notebook.Detail}");
                            Console.WriteLine($"   Quantity: {notebook.Quantity} \n" +
                                $"  __________________________________________________");

                            Console.WriteLine();
                            Console.Write("    Add to cart ? y/n: ");
                            var awnser_notebook = Console.ReadLine().ToUpper();

                            Console.WriteLine();

                            switch (awnser_notebook)
                            {
                                case "Y":
                                    Console.WriteLine("                 (1) Login" +
                                                      "                 (2) Sign Up");
                                    var awnser_user = Convert.ToInt32(Console.ReadLine());

                                    switch (awnser_user)
                                    {
                                        case 1:
                                            Console.Write("Type the number of your account: ");
                                            int a = Convert.ToInt32(Console.ReadLine());
                                            usersService.PostUser(a);
                                            break;
                                        case 2:
                                            break;
                                        default:
                                            break;
                                    }

                                    break;
                                case "N":
                                    break;
                                default:
                                    break;
                            }
                                
                            if (awnser_notebook == "Y")
                            {
                                if (cartService.PostProductCart(notebookId))
                                    Console.WriteLine("      Added with success!  ");
                                else
                                    throw new Exception("The product cannot be placed in the cart!!");

                                Console.WriteLine();
                                Console.Write("      Go to cart page ? y/n: ");
                                var awnserCart = char.Parse(Console.ReadLine());

                                if (awnserCart == 'Y' || awnserCart == 'y')
                                {
                                    Console.Clear();
                                    cartView.ShowCart();
                                }
                                else
                                {
                                    Console.Clear();
                                    homeView.ShowHome();
                                    Console.WriteLine();
                                    ProductsCategoryView();
                                }
                            }
                            else if (awnser_notebook == "N")
                            {
                                Console.WriteLine("Back to home");
                                Console.Clear();
                                homeView.ShowHome();
                            }

                            break;
                        case 3:
                            ProductView cardAcessories = new ProductView();
                            cardAcessories.CardProductCategory("Acessories");
                            var acessories = productsservice.ChooseProductsCategory(CategoryEnum.Acessories);

                            var indexAcessorie = 0;

                            acessories.ForEach(a =>
                            {
                                Console.WriteLine
                                (
                                $"            | ({indexAcessorie}) { a.Name} - R${a.Price} \n"
                                );
                                indexAcessorie++;
                            }
                             );

                            Console.Write("            Select a product: ");
                            var acessorieIndex = Convert.ToInt32(Console.ReadLine());

                            productView.ShowProductCartView();

                            var acessorieId = acessories[acessorieIndex].ProductId;

                            var acessorie = productsservice.GetProduct(acessorieId);
                            Console.WriteLine("  --------------------Acessories-------------------");
                            Console.WriteLine($"   Name: {acessorie.Name}");
                            Console.WriteLine($"   Price: {acessorie.Price}");
                            Console.WriteLine($"   Detail: {acessorie.Detail}");
                            Console.WriteLine($"   Quantity: {acessorie.Quantity} \n" +
                                $"  __________________________________________________");
                            Console.WriteLine();

                            Console.Write("    Add to cart ? y/n: ");
                            var add_acessorie = char.Parse(Console.ReadLine());

                            Console.WriteLine();

                            if (add_acessorie == 'Y' || add_acessorie == 'y')
                            {
                                if (cartService.PostProductCart(acessorieId))
                                    Console.WriteLine("      Added with success!  ");
                                else
                                    throw new Exception("The product cannot be placed in the cart!!");

                                Console.WriteLine();

                                Console.Write("      Go to cart page ? y/n: ");
                                var awnserCart = char.Parse(Console.ReadLine());

                                if (awnserCart == 'Y' || awnserCart == 'y')
                                {
                                    Console.Clear();
                                    cartView.ShowCart();
                                }
                                else if (awnserCart == 'N' || awnserCart == 'n')
                                {
                                    Console.Clear();
                                    homeView.ShowHome();
                                    Console.WriteLine();
                                    ProductsCategoryView();
                                }
                            }
                            else if (add_acessorie == 'N' || add_acessorie == 'n')
                            {
                                Console.WriteLine("Back to home");
                                Console.Clear();
                                homeView.ShowHome();
                            }
                            break;
                        case 4:
                            ProductView cardSmartphones = new ProductView();
                            cardSmartphones.CardProductCategory("Smartphones");

                            var smartphones = productsservice.ChooseProductsCategory(CategoryEnum.Smartphones);

                            var indexSmartphone = 0;

                            smartphones.ForEach(a =>
                            {
                                Console.WriteLine
                                (
                                $"            | ({indexSmartphone}) { a.Name} - R${a.Price} \n"
                                );
                                indexSmartphone++;
                            }
                             );

                            Console.Write("            Select a product: ");
                            var smartphoneIndex = Convert.ToInt32(Console.ReadLine());
                            var smartphoneId = smartphones[smartphoneIndex].ProductId;

                            Console.Clear();

                            var smartphone = productsservice.GetProduct(smartphoneId);

                            Console.WriteLine("           __________________________________________________________________________\n");
                            Console.WriteLine("           -------------------------------- Smartphone ------------------------------\n");
                            Console.WriteLine($"                                    Name: {smartphone.Name}");
                            Console.WriteLine($"                                    Price: {smartphone.Price}");
                            Console.WriteLine($"                                    Detail: {smartphone.Detail}");
                            Console.WriteLine($"                                    Quantity: {smartphone.Quantity} \n" +
                                $"           __________________________________________________________________________\n");
                            Console.WriteLine();
                            Console.Write($"                                   Add {smartphone.Name} to cart ? y/n: ");
                            var awnser_smartphone = char.Parse(Console.ReadLine());

                            Console.WriteLine();

                            if (awnser_smartphone == 'Y' || awnser_smartphone == 'y')
                            {
                                if (cartService.PostProductCart(smartphoneId))
                                    Console.WriteLine("                                              __________________ \n \n" +
                                        "                                              Added with success!  \n" +
                                        "                                              __________________");
                                else
                                    throw new Exception("                                    O produto não pode ser colocado no carrinho!!");

                                Console.WriteLine();
                                Console.Write("                                    Go to cart page ? y/n: ");
                                var awnserCart = char.Parse(Console.ReadLine());

                                if (awnserCart == 'Y' || awnserCart == 'y')
                                {
                                    Console.Clear();
                                    cartView.ShowCart();
                                }
                                else if (awnserCart == 'N' || awnserCart == 'n')
                                {
                                    Console.Clear();
                                    homeView.ShowHome();
                                    Console.WriteLine();
                                    ProductsCategoryView();
                                }
                            }
                            else if (awnser_smartphone == 'N' || awnser_smartphone == 'n')
                            {
                                Console.Clear();
                                homeView.ShowHome();
                                Console.WriteLine();
                                ProductsCategoryView();
                            }
                            break;
                        case 5:
                            ProductView cardTablets = new ProductView();
                            cardTablets.CardProductCategory("Tablets");

                            var tablets = productsservice.ChooseProductsCategory(CategoryEnum.Tablets);

                            var indexTablets = 0;

                            tablets.ForEach(a =>
                            {
                                Console.WriteLine
                                (
                                $"            | ({indexTablets}) { a.Name} - R${a.Price} \n"
                                );
                                indexTablets++;
                            }
                             );

                            Console.Write("            Select a product: ");

                            var tabletIndex = Convert.ToInt32(Console.ReadLine());
                            productView.ShowProductCartView();
                            var tabletId = tablets[tabletIndex].ProductId;

                            var tablet = productsservice.GetProduct(tabletId);

                            Console.WriteLine("  ---------------------Tablets----------------------");
                            Console.WriteLine($"   Name: {tablet.Name}");
                            Console.WriteLine($"   Price: {tablet.Price}");
                            Console.WriteLine($"   Detail: {tablet.Detail}");
                            Console.WriteLine($"   Quantity: {tablet.Quantity} \n" +
                                $"  __________________________________________________");
                            Console.WriteLine();
                            Console.Write("    Add to cart ? y/n: ");
                            var awnser_tablet = char.Parse(Console.ReadLine());

                            Console.WriteLine();

                            if (awnser_tablet == 'Y' || awnser_tablet == 'y')
                            {
                                if (cartService.PostProductCart(tabletId))
                                    Console.WriteLine("      Added with success!  ");
                                else
                                    throw new Exception("O produto não pode ser colocado no carrinho!!");

                                Console.WriteLine();
                                Console.Write("      Go to cart page ? y/n: ");
                                var awnserCart = char.Parse(Console.ReadLine());

                                if (awnserCart == 'Y' || awnserCart == 'y')
                                {
                                    Console.Clear();
                                    cartView.ShowCart();
                                }
                                else if (awnserCart == 'N' || awnserCart == 'n')
                                {
                                    Console.Clear();
                                    homeView.ShowHome();
                                    Console.WriteLine();
                                    ProductsCategoryView();
                                }
                            }
                            else if (awnser_tablet == 'N' || awnser_tablet == 'n')
                            {
                                Console.WriteLine("Back to home");
                                Console.Clear();
                                homeView.ShowHome();
                            }
                            break;
                    }

                    break;
                case 2:
                    CartView cartfirst = new CartView();
                    Console.Clear();
                    cartfirst.ShowCart();
                    break;

                default:
                    Console.Clear();
                    homeView.ShowHome();
                    Console.WriteLine();
                    ProductsCategoryView();
                    break;
            }
        }
    }
}
