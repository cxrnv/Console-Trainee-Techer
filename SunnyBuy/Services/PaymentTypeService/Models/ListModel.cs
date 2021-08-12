using SunnyBuy.Enums;

namespace SunnyBuy.Services.PaymentTypeService.Models
{
    public class ListModel
    {
        public PaymentTypeEnum PaymentTypeEnum { get; set; }
        public string Description { get; set; }
    }
}