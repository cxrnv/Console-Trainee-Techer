using System;
using System.IO;
using System.Linq;
using System.Text;
using SunnyBuy.Enums;
using System.Collections.Generic;

namespace SunnyBuy.Entitities.DB
{
    public class ProductDB
    {
        public ProductDB()
        {

        }

        public List<ProductEntitie> ProductsListDB()
        {
            string path = @"C:\Users\debora.maciel\Desktop\Techer Projects C#\SunnyBuy\Files\Products.csv";

            List<ProductEntitie> productsListDB = new List<ProductEntitie>();

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

                        productsListDB.Add(product);
                    });
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocurred an error");
                Console.WriteLine(e.Message);
            }
            return productsListDB;
        }
    }
}
