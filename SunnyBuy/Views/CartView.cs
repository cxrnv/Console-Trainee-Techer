using SunnyBuy.Services.CartServices;
using SunnyBuy.Services.CartServices.Models;
using System;

namespace SunnyBuy.Views
{
    public class CartView
    {
        HomeView homeView = new HomeView();
        CartService cartService = new CartService();
        public void ShowCart()
        {
            ProductsView productsView = new ProductsView();

            Console.WriteLine("___________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------     Cart       -----------------------------------------");
            Console.WriteLine("___________________________________________________________________________________________________");
            Console.WriteLine();
            var cart = cartService.ShowProductsCart();
            cart.ForEach
                (
                a =>
                    Console.WriteLine
                    (
                        $" +                     {a.Name} " +
                        $" ------------ R${ a.Price}\n"
                    )
                );

            Console.WriteLine(
                "                       (1) Go to the Home \n" +
                "                       (2) Delete cart \n" +
                "                       (3) Buy now "
                );
            Console.WriteLine();
            Console.Write("                       Choose a option: ");
            var awnser = Convert.ToInt32(Console.ReadLine());

            switch (awnser)
            {
                case 1:
                    Console.Clear();
                    homeView.ShowHome();
                    Console.WriteLine();
                    productsView.ProductsCategoryView();
                    break;
                case 2:
                    Console.Write("                       Choose a cart element: ");
                    var cartIndex = Convert.ToInt32(Console.ReadLine());

                    var teste = new PutModel();

                    teste.CartId = cart[cartIndex].CartId;
                    teste.Deleted = true;

                    cartService.PutProductCart(teste);
                    break;
                case 3:
                    PurchaseView purchaseView = new PurchaseView();
                    Console.Clear();
                    purchaseView.PurchaseRegisterView();
                    break;
            }
        }    
    }
}
