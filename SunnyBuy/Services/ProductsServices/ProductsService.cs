using System;
using System.Linq;
using SunnyBuy.Views;
using SunnyBuy.Enums;
using SunnyBuy.Entitities.DB;
using System.Collections.Generic;
using SunnyBuy.Services.ProductsServices.Models;

namespace SunnyBuy.Services.ProductsServices
{
    public class ProductsService
    {
        ProductDB product = new ProductDB();

        public List<ProductsModel> ChooseProductsCategory(CategoryEnum categoryEnum)
        {
            return product.ProductsListDB()
                .Where(a => a.CategoryEnum == categoryEnum)
                .Select(c => new ProductsModel
                {
                    ProductId = c.ProductId,
                    Name = c.Name,
                    Price = c.Price
                }).ToList();
        }

        public List<ProductsModel> Search()
        {
            var products = product.ProductsListDB()
              .Select(p => new ProductsModel
              {
                  ProductId = p.ProductId,
                  Name = p.Name,
                  Price = p.Price
              }).ToList();

            return products;
        }

        public GetModel GetProduct(int productId)
        {
            return product.ProductsListDB()
                .Where(a => a.ProductId == productId)
                .Select(c => new GetModel
                {
                    ProductId = c.ProductId,
                    Name = c.Name,
                    Price = c.Price,
                    Detail = c.Detail,
                    Quantity = c.Quantity 
                }).FirstOrDefault();
        }

        public void ShowProductsCategory(CategoryEnum categoryEnum)
        {
            ProductsService productsservice = new ProductsService();

            var notebooks = productsservice.ChooseProductsCategory(categoryEnum);

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
        }

        public void ChooseOptionsCategory(int choose)
        {
            ProductView productView = new ProductView();
            ProductsService productsservice = new ProductsService();

            switch (choose)
            {
                case 1:
                    productView.CardProductCategory("Computers");
                    productsservice.ShowProductsCategory(CategoryEnum.Computer);

                    var computers = productsservice.ChooseProductsCategory(CategoryEnum.Computer);

                    Console.WriteLine();

                    Console.Write("            Select a product: ");
                    var computerIndex = Convert.ToInt32(Console.ReadLine());
                    var computerId = computers[computerIndex].ProductId;

                    Console.Clear();

                    var computer = productsservice.GetProduct(computerId);

                    ProductView computerView = new ProductView();
                    computerView.CardProduct(computer.Name, computer.Price, computer.Detail, computer.Quantity);

                    Console.Write($"                             Add {computer.Name} to cart ? y/n: ");
                    var awnser_computer = Console.ReadLine().ToUpper();

                    Console.WriteLine();

                    productView.AddProductCardView(awnser_computer, computerId);
                    break;
                case 2:
                    productView.CardProductCategory("Notebooks");
                    productsservice.ShowProductsCategory(CategoryEnum.Notebook);

                    var notebooks = productsservice.ChooseProductsCategory(CategoryEnum.Notebook);

                    Console.WriteLine();

                    Console.Write("            Select a product: ");
                    var notebookIndex = Convert.ToInt32(Console.ReadLine());
                    var notebookId = notebooks[notebookIndex].ProductId;

                    Console.Clear();

                    var notebook = productsservice.GetProduct(notebookId);

                    ProductView notebookView = new ProductView();
                    notebookView.CardProduct(notebook.Name, notebook.Price, notebook.Detail, notebook.Quantity);

                    Console.Write($"                             Add {notebook.Name} to cart ? y/n: ");
                    var awnser_notebook = Console.ReadLine().ToUpper();

                    Console.WriteLine();

                    productView.AddProductCardView(awnser_notebook, notebookId);
                    break;
                case 3:
                    productView.CardProductCategory("Acessories");
                    productsservice.ShowProductsCategory(CategoryEnum.Acessories);

                    var acessories = productsservice.ChooseProductsCategory(CategoryEnum.Acessories);

                    Console.WriteLine();

                    Console.Write("            Select a product: ");
                    var acessorieIndex = Convert.ToInt32(Console.ReadLine());
                    var acessorieId = acessories[acessorieIndex].ProductId;

                    Console.Clear();

                    var acessorie = productsservice.GetProduct(acessorieId);

                    ProductView acessorieView = new ProductView();
                    acessorieView.CardProduct(acessorie.Name, acessorie.Price, acessorie.Detail, acessorie.Quantity);

                    Console.Write($"                             Add {acessorie.Name} to cart ? y/n: ");
                    var awnser_acessorie = Console.ReadLine().ToUpper();

                    Console.WriteLine();

                    productView.AddProductCardView(awnser_acessorie, acessorieId);
                    break;
                case 4:
                    productView.CardProductCategory("Smartphones");
                    productsservice.ShowProductsCategory(CategoryEnum.Smartphones);

                    var smartphones = productsservice.ChooseProductsCategory(CategoryEnum.Smartphones);

                    Console.WriteLine();

                    Console.Write("            Select a product: ");
                    var smartphoneIndex = Convert.ToInt32(Console.ReadLine());
                    var smartphoneId = smartphones[smartphoneIndex].ProductId;

                    Console.Clear();

                    var smartphone = productsservice.GetProduct(smartphoneId);

                    ProductView smartphoneView = new ProductView();
                    smartphoneView.CardProduct(smartphone.Name, smartphone.Price, smartphone.Detail, smartphone.Quantity);

                    Console.Write($"                             Add {smartphone.Name} to cart ? y/n: ");
                    var awnser_smartphone = Console.ReadLine().ToUpper();

                    Console.WriteLine();

                    productView.AddProductCardView(awnser_smartphone, smartphoneId);
                    break;
                case 5:
                    productView.CardProductCategory("Tablets");
                    productsservice.ShowProductsCategory(CategoryEnum.Tablets);

                    var tablets = productsservice.ChooseProductsCategory(CategoryEnum.Tablets);

                    Console.WriteLine();

                    Console.Write("            Select a product: ");
                    var tabletIndex = Convert.ToInt32(Console.ReadLine());
                    var tabletId = tablets[tabletIndex].ProductId;

                    Console.Clear();

                    var tablet = productsservice.GetProduct(tabletId);

                    ProductView tabletView = new ProductView();
                    tabletView.CardProduct(tablet.Name, tablet.Price, tablet.Detail, tablet.Quantity);

                    Console.Write($"                             Add {tablet.Name} to cart ? y/n: ");
                    var awnser_tablet = Console.ReadLine().ToUpper();

                    Console.WriteLine();

                    productView.AddProductCardView(awnser_tablet, tabletId);
                    break;
            }
        }
    }
}
