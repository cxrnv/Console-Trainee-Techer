using SunnyBuy.Enums;

namespace SunnyBuy.Entitities
{
    public class ProductEntitie
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Detail { get; set; }
        public int Quantity { get; set; }
        public int Rank { get; set; }
        public CategoryEnum CategoryEnum { get; set; }
    }
}