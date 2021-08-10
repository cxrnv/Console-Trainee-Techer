using System;
using System.IO;
using System.Linq;
using System.Text;
using SunnyBuy.Enums;
using System.Collections.Generic;
using SunnyBuy.Services.UsersServices.Models;
using SunnyBuy.Services.UsersServices;

namespace SunnyBuy.Entitities.DB
{
    public class ClientDB
    {
        string path = @"C:\Users\debora.maciel\Desktop\Techer Projects C#\SunnyBuy\Files\Client.csv";

        string header = "";

        public List<Client> ClientsList()
        {
            List<Client> usersList = new List<Client>();

            try
            {
                var carts = File.ReadAllLines(path, Encoding.UTF8);

                header = carts[0];

                carts.Skip(1)
                    .ToList()
                    .ForEach(
                    c =>
                    {

                        var fields = c.Split(';');

                        var user = new Client();

                        user.ClientId = int.Parse(fields[0]);
                        user.ClientCpf = (fields[1]);
                        user.Name = (fields[2]);
                        user.Email = (fields[3]);
                        user.Address = (fields[4]);
                        user.Phone = (fields[5]);

                        usersList.Add(user);
                    });
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocurred an error");
                Console.WriteLine(e.Message);
            }

            return usersList;
        }

        public bool PostUserEntity(ListModel model)
        {
            try
            {
                var clients = ClientsList();

                var modelEntity = new Client();

                modelEntity.ClientId = clients.Count() + 1;
                modelEntity.ClientCpf = model.Cpf;
                modelEntity.Name = model.Name;
                modelEntity.Email = model.Email;
                modelEntity.Address = model.Address;
                modelEntity.Phone = model.Phone;

                clients.Add(modelEntity);

                var lines = new List<string>();

                lines.Add(header);

                foreach (var item in clients)
                {
                    var aux = new string[] 
                    { 
                        item.ClientId.ToString(), 
                        item.ClientCpf.ToString(), 
                        item.Name.ToString(), 
                        item.Email.ToString(), 
                        item.Address.ToString(), 
                        item.Phone.ToString() 
                    };

                    lines.Add(String.Join(";", aux));
                }

                File.WriteAllLines(path, lines);
            }
            catch (IOException e)
            {
                Console.WriteLine("Ocurred an error");
                Console.WriteLine(e.Message);
            }
            return true;
        }
    }
}
