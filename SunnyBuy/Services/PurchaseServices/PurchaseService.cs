using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SunnyBuy.Services.PurchaseServices.Models;
using SunnyBuy.Services.CartServices;
using SunnyBuy.Services.CreditCardServices.Models;

namespace SunnyBuy.Services.PurchaseServices
{
    public class PurchaseService
    {
        CartService cartService = new CartService(contextVar);
        protected readonly Context.Context context;
        CreditCardService cardService = new CreditCardService(contextVar);
        static Context.Context contextVar = new Context.Context();

        public PurchaseService(Context.Context context)
        {
            this.context = context;
        }

        public PurchaseService()
        {

        }

        public void ShowPurchase(int clientId)
        {
            cartService.ShowProductsCart(clientId);
        }
    }
}
