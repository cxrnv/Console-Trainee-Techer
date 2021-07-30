using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyBuy.Services.UsersServices.Models
{
    public class ListModel
    {
        public int UserId { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
