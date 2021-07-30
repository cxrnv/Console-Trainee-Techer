using SunnyBuy.Entitities;
using SunnyBuy.Enums;
using System;

namespace SunnyBuy.Services.PurchaseServices
{
    public class PurchaseService
    {
        UserEntitie user = new UserEntitie();
        PaymentType payment = new PaymentType();
        public void User(string name, string email, string address, string phone, PaymentType paymentType )
        {
            user.Name = name;
            user.Email = email;
            user.Address = address;
            user.Phone = phone;
            user.Payment = paymentType;

            /*Console.Write("*           Name: ");
            user.Name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("*           E mail: ");
            user.Email = Console.ReadLine();
            Console.WriteLine();

            Console.Write("*           Type the address: ");
            user.Address = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("           Payment types: \n" +
                "                        (1) CreditCard \n" +
                "                        (2) Billet \n" +
                "                        (3) Pix");

            Console.WriteLine();
            Console.Write("           Choose the payment type: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            payment = (PaymentType)choice;
            Console.WriteLine();

            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Type the card's number: ");

                    break;
                case 2:
                    Random billet = new Random();
                    int codeBillet = billet.Next(1849802013);
                    Console.WriteLine($"           Billet Code: {codeBillet}");
                    break;
                case 3:
                    Random pix = new Random();
                    int codePix = pix.Next(222202013);
                    Console.WriteLine(codePix);
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("           Confirm Purchase ? y/n");
            var confirm_awnser = Console.ReadLine();

            switch (confirm_awnser)
            {
                case "y":
                    Console.Clear();

                    break;
                case "n":
                    break;
                default:
                    var confirm_anwser = Console.ReadLine();
                    break;
            }*/

        }

    }
}
