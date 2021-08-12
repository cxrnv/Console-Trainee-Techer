using SunnyBuy.Services.PaymentTypeService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyBuy.Services.PaymentTypeService
{
    public class PaymentTypeService
    {
        protected readonly Context.Context context;

        public PaymentTypeService(Context.Context context)
        {
            this.context = context;
        }

        public PaymentTypeService()
        {

        }

        public bool AddPaymentType(ListModel model)
        {
            var paymentType = new Entitities.PaymentType
            {
                PaymentTypeEnum = model.PaymentTypeEnum,
                Description = model.Description                
            };

            context.PaymentType.Add(paymentType);
            context.SaveChanges();

            return true;
        }
    }
}
