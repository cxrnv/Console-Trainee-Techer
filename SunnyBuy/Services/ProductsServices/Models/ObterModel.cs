using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyBuy.Services.ProductsServices.Models
{
    public class ObterModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Detail { get; set; }
        public int Quantity { get; set; }
    }
}
