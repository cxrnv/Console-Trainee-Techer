using System;

namespace SunnyBuy.Views
{
    public class HomeView
    {
        public void ShowHome()
        {
            ShowNav();
            Console.WriteLine("                ------------------------  Wellcome to SunnyBuy :) --------------------------");
            Console.WriteLine("                ____________________________________________________________________________\n");
        }

        public void ShowNav()
        {
            Console.WriteLine("                ____________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("                -----------------------------   SunnyBuy  ----------------------------------");
            Console.WriteLine("                ____________________________________________________________________________\n");
        }
    }
}
