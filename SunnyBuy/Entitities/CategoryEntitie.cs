using System.ComponentModel.DataAnnotations;

namespace SunnyBuy.Entitities
{
    public class CategoryEntitie
    {
        [Key]
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
