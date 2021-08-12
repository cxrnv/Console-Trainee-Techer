using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SunnyBuy.Services.PurchaseServices.Models;
using SunnyBuy.Services.CartServices;
using SunnyBuy.Services.CreditCardServices.Models;
using PurchaseListModel = SunnyBuy.Services.PurchaseServices.Models.PurchaseListModel;

namespace SunnyBuy.Services.PurchaseServices
{
    public class PurchaseService
    {
        protected readonly Context.Context context;
        CartService cartService = new CartService(contextVar);
        static Context.Context contextVar = new Context.Context();
        CreditCardService cardService = new CreditCardService(contextVar);

        public PurchaseService(Context.Context context)
        {
            this.context = context;
        }

        public PurchaseService()
        {

        }

        
        public bool PostPurchase(PurchaseListModel model)
        {
            var purchase = new Entitities.Purchase
            {
                PurchaseId = model.PurchaseId,
                DatePurchase = model.DatePurchase,
                PaymentTypeEnum = model.PaymentTypeEnum,
                ClientId = model.ClientId,
                CartId = model.CartId
            };

            context.Purchase.Add(purchase);
            context.SaveChanges();

            return true;
        }
    }
}
