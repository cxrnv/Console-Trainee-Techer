using System;

namespace SunnyBuy.Services.CartServices.Models
{
    public class ListModel
    {
        public Guid CartId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateInclude { get; set; }
        public bool Deleted { get; set; }
    }
}
