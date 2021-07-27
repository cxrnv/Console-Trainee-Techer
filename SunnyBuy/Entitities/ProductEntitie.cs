using SunnyBuy.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SunnyBuy.Entitities
{
    public class ProductEntitie
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Detail { get; set; }
        public int Quantity { get; set; }
        public CategoryEnum Category { get; set; }
        public int Rank { get; set; }
        public CategoryEnum CategoryEnum { get; set; }

        public ProductEntitie()
        {

        }
        public ProductEntitie(int productid, string name, float price, string detail, int quantity, CategoryEnum category, int rank)
        {
            ProductId = productid;
            Name = name;
            Price = price;
            Detail = detail;
            Quantity = quantity;
            Category = category;
            Rank = rank;
        }
        public List<ProductEntitie> ProductsList()
        {
            string path = @"C:\Users\debora.maciel\Desktop\Techer Projects C#\SunnyBuy\Files\Products.csv";

            List<ProductEntitie> productsList = new List<ProductEntitie>();

            try
            {
                var products = File.ReadAllLines(path, Encoding.UTF8);

                products.Skip(1)
                    .ToList()
                    .ForEach(p => {

                        var fields = p.Split(';');

                        var product = new ProductEntitie();
                        product.ProductId = int.Parse(fields[0]);
                        product.Name = fields[1];
                        product.Price = float.Parse(fields[2]);
                        product.Detail = fields[3];
                        product.Quantity = int.Parse(fields[4]);

                        Enum.TryParse(fields[5], out CategoryEnum category);
                        product.CategoryEnum = category;

                        productsList.Add(product);
                    });
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocurred an error");
                Console.WriteLine(e.Message);
            }
            return productsList;
        }
    }
}
