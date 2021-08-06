using System;
using System.Linq;
using SunnyBuy.Services.CartServices.Models;
using System.Collections.Generic;
using SunnyBuy.Entitities.DB;

namespace SunnyBuy.Services.CartServices
{
    public class CartService
    {
        CartDB cart = new CartDB();
        ProductDB product = new ProductDB();

        public List<ListModel> GetProductsCart(int productId)
        {
            return product.ProductsListDB()
                .Where(a => a.ProductId == productId)
                .Select(c => new ListModel
                {
                    ProductId = c.ProductId,
                    Name = c.Name,
                    Price = c.Price
                })
                .ToList();
        }

        public bool PostProductCart(int productId)
        {
            var model = new PostModel();

            model.ProductId = productId;
            model.DateInclude = DateTime.Now;
            model.Deleted = false;
            model.UserId = 1;

            return cart.PostCartEntity(model);
        }

        public List<ListModel> ShowProductsCart()
        {
            var carts = cart.CartsListDB()
                                .Where(a => a.UserId == a.UserId && !a.Deleted)
                                .Select(b => new
                                {
                                    b.CartId,
                                    b.ProductId,
                                    b.DateInclude
                                })
                                .ToList();

            var products = product.ProductsListDB()
                .Where(a => carts.Any(c => c.ProductId == a.ProductId))
                .Select(b => new ListModel
                {
                    ProductId = b.ProductId,
                    Name = b.Name,
                    Price = b.Price
                }
                ).ToList();

            foreach (var item in products)
            {
                var cart = carts.Find(a => a.ProductId == item.ProductId);

                item.CartId = cart.CartId;
                item.DateInclude = cart.DateInclude;
            }

            return products;
        }

        public bool PutProductCart(PutModel model)
        {
            return cart.PutCartEntity(model);
        }
    }
}
