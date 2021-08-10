using System.Linq;
using SunnyBuy.Entitities.DB;
using System.Collections.Generic;
using SunnyBuy.Services.UsersServices.Models;

namespace SunnyBuy.Services.UsersServices
{
    public class ClientService
    {
        CartDB cart = new CartDB();
        ClientDB clients = new ClientDB();

        public List<ListModel> GetClients(string cpf)
        {
            return clients.ClientsList()
                .Where(a => a.ClientCpf == cpf)
                .Select(c => new ListModel
                {
                    ClientId = c.ClientId,
                    Cpf = c.ClientCpf,
                    Name = c.Name,
                    Email = c.Email,
                    Address = c.Address,
                    Phone = c.Phone
                })
                .ToList();
        }

        public bool Login(string email)
        {
            if (clients.ClientsList()
                 .Any(e => e.Email == email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PostUser(ListModel model)
        {
            return clients.PostUserEntity(model);
        }

        public List<ListModel> ShowClientCart()
        {
            var carts = cart.CartsListDB()
                                .Where(a => !a.Deleted)
                                .Select(b => new
                                {
                                    b.CartId,
                                    b.ClientId
                                })
                                .ToList();

            var clients_cart = clients.ClientsList()
                .Where(a => carts.Any(c => c.ClientId == a.ClientId))
                .Select(b => new ListModel
                {
                    ClientId = b.ClientId,
                    Name = b.Name,
                    Email = b.Email,
                    Address = b.Address,
                    Cpf = b.ClientCpf,
                    Phone = b.Phone
                }
                ).ToList();

            foreach (var item in carts)
            {
                var cart = carts.Find(a => a.ClientId == item.ClientId);
            }

            return clients_cart;
        }
    }
}
