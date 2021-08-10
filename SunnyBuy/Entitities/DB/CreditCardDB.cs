using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using SunnyBuy.Services.CreditCardServices.Models;

namespace SunnyBuy.Entitities.DB
{
    public class CreditCardDB
    {
        string path = @"C:\Users\debora.maciel\Desktop\Techer Projects C#\SunnyBuy\Files\CreditCard.csv";

        string header = "";

        public List<CreditCard> CreditCardList()
        {
            List<CreditCard> cardsList = new List<CreditCard>();

            try
            {
                var cards = File.ReadAllLines(path, Encoding.UTF8);

                header = cards[0];

                cards.Skip(1)
                    .ToList()
                    .ForEach(p =>
                    {

                        var fields = p.Split(';');

                        var card = new CreditCard();

                        card.CreditCardId = int.Parse(fields[0]);
                        card.Operator = fields[1];
                        card.Number = fields[2];
                        card.DueDate = DateTime.Parse(fields[3]);
                        card.SecurityCode = int.Parse(fields[4]);
                        card.ClientCpf = fields[5];

                        cardsList.Add(card);
                    });
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocurred an error");
                Console.WriteLine(e.Message);
            }

            return cardsList;
        }

        public bool PostUserEntity(ListModel model)
        {
            try
            {
                var cards = CreditCardList();

                var modelEntity = new CreditCard();

                modelEntity.CreditCardId = cards.Count() + 1;
                modelEntity.Operator = model.Operator;
                modelEntity.Number = model.Number;
                modelEntity.DueDate = model.DueDate;
                modelEntity.SecurityCode = model.SecurityCode;
                modelEntity.ClientCpf = model.ClientCpf;

                cards.Add(modelEntity);

                var lines = new List<string>();

                lines.Add(header);

                foreach (var item in cards)
                {
                    var aux = new string[]
                    {
                        item.CreditCardId.ToString(),
                        item.Operator.ToString(),
                        item.Number.ToString(),
                        item.DueDate.ToString(),
                        item.SecurityCode.ToString(),
                        item.ClientCpf.ToString()
                    };

                    lines.Add(String.Join(";", aux));
                }

                File.WriteAllLines(path, lines);
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocurred an error");
                Console.WriteLine(e.Message);
            }
            return true;
        }
    }
}