using System;

namespace SunnyBuy.Views
{
    public class ProductView
    {
        public void ShowProductCartView()
        {
            Console.Clear();
            Console.WriteLine("  __________________________________________________");
        }

        public void CardProductCategory(string category)
        {
            Console.WriteLine("            ____________________________________________________");
            Console.WriteLine();
            Console.WriteLine($"                                 Home > Category ");
            Console.WriteLine("            ____________________________________________________");
            Console.WriteLine();
            Console.WriteLine($"            ---------------------- {category} -------------------");
            Console.WriteLine("            ____________________________________________________");
            Console.WriteLine();
        }
    }
}
