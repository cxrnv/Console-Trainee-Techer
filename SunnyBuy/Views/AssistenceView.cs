using System;

namespace SunnyBuy.Views
{
    public class AssistenceView
    {
        public void Assistence()
        {
            Console.WriteLine("  __________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("  -----------------------------------   SunnyBuy Assistence --------------------------------");
            Console.WriteLine("  __________________________________________________________________________________________ \n");
            Console.Write("      * Whats going on ? ");
            var awnser = Console.ReadLine();
            Console.WriteLine();

            Console.Write("      * Email: ");
            var email = Console.ReadLine();
            Console.WriteLine();

            Console.Write("      * Phone: ");
            var phone = Console.ReadLine();

            while (phone.Length != 11)
            {
                Console.Write("      * Number phone must have 11 characters :");
                phone = Console.ReadLine();
            }
            Console.WriteLine();

            Console.WriteLine("  -------------------------------------------------------------------------------------------");
            Console.WriteLine("                              Thanks for the message, we will contact you ! ");
            Console.WriteLine("  -------------------------------------------------------------------------------------------");
        }
    }
}
