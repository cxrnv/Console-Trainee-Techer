using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SunnyBuy.Services.CartServices.Models;

namespace SunnyBuy.Services.CartServices
{
    public class CartService
    {
        protected readonly Context.Context context;

        public CartService(Context.Context context)
        {
            this.context = context;
        }

        public CartService()
        {

        }

        public bool AddProductCart(int clientId, int productId)
        {
            var model = new Entitities.Cart()
            {
                ClientId = clientId,
                ProductId = productId,
                DateInclude = DateTime.Now,
                Deleted = false
            };

            context.Cart.Add(model);
            context.SaveChanges();

            return true;
        }

        public List<ListModel> ShowProductsCart(int clientId)
        {
            var products = new List<ListModel>();

            try
            {
                var carts = context.Cart
                    .Include(a => a.Product)
                    .Where(a => a.ClientId == clientId && !a.Deleted);

                if (carts == null)
                    throw new Exception("This client doesn't have products in the cart ");

                products = carts.Select(b => new ListModel
                {
                    CartId = b.CartId,
                    ProductId = b.ProductId,
                    Name = b.Product.Name,
                    Price = b.Product.Price,
                    DateInclude = b.DateInclude
                }).ToList();

            }
            catch (IOException e)
            {
                Console.WriteLine("Ocurred an error");
                Console.WriteLine(e);
            }

            return products;
        }

        public bool PutProductCart(PutModel model)
        {
            try
            {
                var cart = context.Cart
                    .Where(a => a.CartId == model.CartId && !model.Deleted)
                    .FirstOrDefault();

                cart.Deleted = model.Deleted;

                context.Cart.UpdateRange();
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurred and error");
                Console.WriteLine(e);
            }

            return true;
        }
    }
}
