using SunnyBuy.Services.CartServices.Models;
using System;
using System.Collections.Generic;

namespace SunnyBuy.Services.CartServices
{
    public class CartService
    {
        List<ListModel> cart = new List<ListModel>();

        public void Add(int productId)
        {
            var model = new ListModel();

            model.CartId = Guid.NewGuid();
            model.ProductId = productId;
            model.DateInclude = DateTime.Now;
            model.Deleted = false;

            cart.Add(model);
        }


    }
}
