using SunnyBuy.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Entitities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Detail { get; set; }
        public int Quantity { get; set; }
        public int Rank { get; set; }
        
        [Column ("CategoryId")]
        public CategoryEnum CategoryEnum { get; set; }

        [ForeignKey(nameof(CategoryEnum))]
        public Category Category { get; set; }
    }
}