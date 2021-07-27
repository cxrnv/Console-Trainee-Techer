using System;

namespace SunnyBuy.Views
{
    public class HomeView
    {
        public void ShowHome()
        {
            Console.WriteLine("---------SunnyBuy---------");
            Console.WriteLine("    Choose a category       ");
            Console.WriteLine
                ("1       Computers \n" +
                 "2       Notebooks \n" +
                 "3       Acessories \n" +
                 "4       Smartphones \n" +
                 "5       Tablets");
        }
    }
}
