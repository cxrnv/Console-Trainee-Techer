using System.Linq;
using System.Collections.Generic;
using SunnyBuy.Services.UsersServices.Models;

namespace SunnyBuy.Services.UsersServices
{
    public class ClientService
    {
        protected readonly Context.Context context;

        public ClientService(Context.Context context)
        {
            this.context = context;
        }

        public List<ListModel> GetClients(string cpf)
        {
            return context.Client
                .Where(a => a.ClientCpf == cpf)
                .Select(c => new ListModel
                {
                    ClientId = c.ClientId,
                    Cpf = c.ClientCpf,
                    Name = c.Name,
                    Email = c.Email,
                    Address = c.Address,
                    Phone = c.Phone
                }).ToList();
        }

        public bool Login(string email)
        {
            if (context.Client
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
            var client = new Entitities.Client
            {
                ClientCpf = model.Cpf,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Address = model.Address,
                Phone = model.Phone
            };

            context.Client.Add(client);
            context.SaveChanges();

            return true;
        }
    }
}
