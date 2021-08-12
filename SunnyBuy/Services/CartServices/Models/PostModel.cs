using System;

namespace SunnyBuy.Services.CartServices.Models
{
    public class PostModel
    {
        public int CartId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public DateTime DateInclude { get; set; }
        public bool Deleted { get; set; }
    }
}
