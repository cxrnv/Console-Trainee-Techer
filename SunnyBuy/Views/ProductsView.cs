using SunnyBuy.Services.ProductsServices;
using SunnyBuy.Enums;
using System;
using SunnyBuy.Services.CartServices;
using SunnyBuy.Services.CartServices.Models;
using System.Linq;

namespace SunnyBuy.Views
{
    public class ProductsView
    {
        CartService cartService = new CartService();
        ProductsService productsservice = new ProductsService();
        public void ProductsCategoryView()
        {
            var chooseCategory = Convert.ToInt32(Console.ReadLine());

            switch (chooseCategory)
            {
                case 1:
                    var computer = productsservice.ChooseProductsCategory(CategoryEnum.Computer);
                    computer.ForEach(a =>
                    System.Console.WriteLine
                    (
                        $"{ a.Name} - R${a.Price}"
                    ));
                    break;
                case 2:
                    var notebooks = productsservice.ChooseProductsCategory(CategoryEnum.Notebook);
                    notebooks.ForEach(a =>
                    System.Console.WriteLine
                    (
                        $"{ a.Name} - R${a.Price}"
                    ));
                    break;
                case 3:
                    var acessories = productsservice.ChooseProductsCategory(CategoryEnum.Acessories);
                    acessories.ForEach(a =>
                    System.Console.WriteLine
                    (
                        $"{ a.Name} - R${a.Price}"
                    ));
                    break;
                case 4:
                    var smartphones = productsservice.ChooseProductsCategory(CategoryEnum.Smartphones);
                    smartphones.ForEach(a =>
                    System.Console.WriteLine
                    (
                        $"{ a.Name} - R${a.Price}"
                    ));
                    break;
                case 5:
                    var tablets = productsservice.ChooseProductsCategory(CategoryEnum.Tablets);

                    var index = 0;

                    tablets.ForEach(a =>
                    {
                        System.Console.WriteLine
                        (
                        $"{index}: { a.Name} - R${a.Price}"
                        );
                        index++;
                        }
                    );


                    Console.WriteLine("Select a product: ");

                    var tabletIndex = Convert.ToInt32(Console.ReadLine());

                    var tabletId = tablets[tabletIndex].ProductId;

                    var tablet = productsservice.ObterProduto(tabletId);

                    Console.WriteLine($" Product Name: {tablet.Name}");
                    Console.WriteLine($" Product Price: {tablet.Price}");
                    Console.WriteLine($" Product Detalhe: {tablet.Detail}");
                    Console.WriteLine($" Product Quantity: {tablet.Quantity}");
                    break;
            }
        }
    }
}
