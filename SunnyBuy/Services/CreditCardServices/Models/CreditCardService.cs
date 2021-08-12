using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SunnyBuy.Services.CreditCardServices.Models
{
    public class CreditCardService
    {
        protected readonly Context.Context context;

        public CreditCardService(Context.Context context)
        {
            this.context = context;
        }

        public CreditCardService()
        {

        }

        public bool AddCreditCard(ListModel model) 
        {
            var card = new Entitities.CreditCard()
            {
                ClientId = model.ClientId,
                DueDate = model.DueDate,
                Number = model.Number,
                Operator = model.Operator
            };

            context.CreditCard.Add(card);
            context.SaveChanges();

            return true;
        }

        public List<ListModel> ShowAllCreditCard(int clientId)
        {
            return context.CreditCard
                .Select(c => new ListModel() 
                { 
                    ClientId = clientId,
                    CreditCardId = c.CreditCardId,
                    Operator = c.Operator,
                    Number = c.Number,
                    DueDate = c.DueDate,
                    SecurityCode = c.SecurityCode
                } ).ToList();
        }
    }
}
