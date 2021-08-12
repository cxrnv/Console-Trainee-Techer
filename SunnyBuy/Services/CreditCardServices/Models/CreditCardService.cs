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

        public bool AddCreditCard(CreditCardListModel model) 
        {
            var card = new Entitities.CreditCard()
            {
                ClientId = model.ClientId,
                DueDate = model.DueDate,
                Number = model.Number,
                SecurityCode = model.SecurityCode,
                Operator = model.Operator
            };

            context.CreditCard.Add(card);
            context.SaveChanges();

            return true;
        }
    }
}