﻿using SunnyBuy.Enums;

namespace SunnyBuy.Entitities
{
    public class UserEntitie
    {
        public int UserId { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public PaymentType Payment { get; set; }
    }
}
