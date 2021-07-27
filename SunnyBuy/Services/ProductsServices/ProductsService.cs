using SunnyBuy.Entitities;
using SunnyBuy.Enums;
using SunnyBuy.Services.ProductsServices.Models;
using System.Collections.Generic;
using System.Linq;

namespace SunnyBuy.Services.ProductsServices
{
    public class ProductsService
    {
        ProductEntitie product = new ProductEntitie();

        public List<ProductsModel> ChooseProductsCategory(CategoryEnum categoryEnum)
        {
            return product.ProductsList()                
                .Where(a => a.CategoryEnum == categoryEnum)
                .Select(c => new ProductsModel
                {
                    ProductId = c.ProductId,
                    Name = c.Name,
                    Price = c.Price
                }).ToList();
        }

        public ObterModel ObterProduto(int produtoId)
        {
            return product.ProductsList()
                .Where(a => a.ProductId == produtoId)
                .Select(c => new ObterModel
                {
                    ProductId = c.ProductId,
                    Name = c.Name,
                    Price = c.Price,
                    Detail = c.Detail,
                    Quantity = c.Quantity
                }).FirstOrDefault();
        }
    }
}
