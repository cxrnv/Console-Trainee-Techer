using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SunnyBuy.Entitities
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientCpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public int PaymentTypeId { get; set; }

        [ForeignKey(nameof(PaymentTypeId))]
        public PaymentType PaymentType { get; set; }
    }
}