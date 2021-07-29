using SunnyBuy.Services.ProductsServices;
using SunnyBuy.Enums;
using System;
using SunnyBuy.Services.CartServices;

namespace SunnyBuy.Views
{
    public class ProductsView
    {
        CartView cartView = new CartView();
        HomeView homeView = new HomeView();
        ProductView productView = new ProductView();
        CartService cartService = new CartService();
        ProductsService productsservice = new ProductsService();
        Program program = new Program();
        public void ProductsCategoryView()
        {
            Console.Write("    Type the number's page here: ");
            var chooseCategory = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (chooseCategory)
            {
                case 1:
                    Console.WriteLine("   _______________________________________________");
                    Console.WriteLine("   --------------------Computers------------------");
                    Console.WriteLine();
                    var computers = productsservice.ChooseProductsCategory(CategoryEnum.Computer);

                    var indexComputer = 0;

                    computers.ForEach(a =>
                    {
                        Console.WriteLine
                        (
                        $"({indexComputer}) { a.Name} - R${a.Price}"
                        );
                        indexComputer++;
                    }
                    );

                    Console.WriteLine();
                    Console.Write("Select a product: ");
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
                    var notebooks = productsservice.ChooseProductsCategory(CategoryEnum.Notebook);

                    var indexNotebook = 0;

                    notebooks.ForEach(a =>
                    {
                        System.Console.WriteLine
                        (
                        $"({indexNotebook}) { a.Name} - R${a.Price}"
                        );
                        indexNotebook++;
                    }
                    );

                    Console.WriteLine("Select a product: ");
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
                    var awnser_notebook = char.Parse(Console.ReadLine());

                    Console.WriteLine();

                    if (awnser_notebook == 'Y' || awnser_notebook == 'y')
                    {
                        if (cartService.PostProductCart(notebookId))
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
                        else
                        {
                            Console.Clear();
                            homeView.ShowHome();
                            Console.WriteLine();
                            ProductsCategoryView();
                        }
                    }
                    else if (awnser_notebook == 'N' || awnser_notebook == 'n')
                    {
                        Console.WriteLine("Back to home");
                        Console.Clear();
                        homeView.ShowHome();
                    }

                    break;

                case 3:
                    var acessories = productsservice.ChooseProductsCategory(CategoryEnum.Acessories);

                    var indexAcessorie = 0;

                    acessories.ForEach(a =>
                    {
                        System.Console.WriteLine
                        (
                        $"({indexAcessorie}) { a.Name} - R${a.Price}"
                        );
                        indexAcessorie++;
                    }
                    );

                    Console.Write("Select a product: ");
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
                    var smartphones = productsservice.ChooseProductsCategory(CategoryEnum.Smartphones);

                    var indexSmartphone = 0;

                    smartphones.ForEach(a =>
                    {
                        System.Console.WriteLine
                        (
                        $"({indexSmartphone}) { a.Name} - R${a.Price}"
                        );
                        indexSmartphone++;
                    }
                    );

                    Console.WriteLine("Select a product: ");
                    var smartphoneIndex = Convert.ToInt32(Console.ReadLine());
                    productView.ShowProductCartView();
                    var smartphoneId = smartphones[smartphoneIndex].ProductId;

                    var smartphone = productsservice.GetProduct(smartphoneId);

                    Console.WriteLine("  --------------------Smartphones-------------------");
                    Console.WriteLine($"   Name: {smartphone.Name}");
                    Console.WriteLine($"   Price: {smartphone.Price}");
                    Console.WriteLine($"   Detail: {smartphone.Detail}");
                    Console.WriteLine($"   Quantity: {smartphone.Quantity} \n" +
                        $"  __________________________________________________");
                    Console.WriteLine();
                    Console.Write("    Add to cart ? y/n: ");
                    var awnser_smartphone = char.Parse(Console.ReadLine());

                    Console.WriteLine();

                    if (awnser_smartphone == 'Y' || awnser_smartphone == 'y')
                    {
                        if (cartService.PostProductCart(smartphoneId))
                            Console.WriteLine("      Added with success!  ");
                        else
                            throw new Exception("O produto não pode ser colocado no carrinho!!");

                        Console.WriteLine();
                        Console.Write("      Go to cart page ? y/n: ");
                        var awnserCart = char.Parse(Console.ReadLine());

                        if (awnser_smartphone == 'Y' || awnser_smartphone == 'y')
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
                    else if (awnser_smartphone == 'N' || awnser_smartphone == 'n')
                    {
                        Console.WriteLine("Back to home");
                        Console.Clear();
                        homeView.ShowHome();
                    }
                    break;
                case 5:
                    var tablets = productsservice.ChooseProductsCategory(CategoryEnum.Tablets);

                    var indexTablet = 0;

                    tablets.ForEach(a =>
                    {
                        System.Console.WriteLine
                        (
                        $"({indexTablet}) { a.Name} - R${a.Price}"
                        );
                        indexTablet++;
                    }
                    );

                    Console.WriteLine("Select a product: ");

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

                        if (awnser_tablet == 'Y' || awnser_tablet == 'y')
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
                    else if (awnser_tablet == 'N' || awnser_tablet == 'n')
                    {
                        Console.WriteLine("Back to home");
                        Console.Clear();
                        homeView.ShowHome();
                    }
                    break;
            }
        }
    }
}
