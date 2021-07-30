using SunnyBuy.Enums;
using SunnyBuy.Services.UsersServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SunnyBuy.Entitities.DB
{
    public class UserDB
    {
        string path = @"C:\Users\debora.maciel\Desktop\Techer Projects C#\SunnyBuy\Files\Users.csv";

        string header = "";
        public List<UserEntitie> UsersList()
        {
            List<UserEntitie> usersList = new List<UserEntitie>();

            try
            {
                var carts = File.ReadAllLines(path, Encoding.UTF8);

                header = carts[0];

                carts.Skip(1)
                    .ToList()
                    .ForEach(p => {

                        var fields = p.Split(';');

                        var user = new UserEntitie();

                        user.UserId = int.Parse(fields[0]);
                        user.Name = (fields[1]);
                        user.Email = (fields[2]);
                        user.Address = (fields[3]);
                        user.Phone = (fields[4]);

                        Enum.TryParse(fields[5], out PaymentType payment);
                        user.Payment = payment;

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

        public bool PostUserEntity(PostModel model)
        {
            try
            {
                var users = UsersList();

                var modelEntity = new UserEntitie();

                modelEntity.UserId = users.Count() + 1;
                modelEntity.Name = model.Name;
                modelEntity.Email = model.Email;
                modelEntity.Address = model.Address;
                modelEntity.Cpf = model.Cpf;
                modelEntity.Phone = model.Phone;

                users.Add(modelEntity);

                var lines = new List<string>();

                lines.Add(header);

                foreach (var item in users)
                {
                    var aux = new string[] { item.UserId.ToString(), item.Name.ToString(), item.Email.ToString(), item.Address.ToString(), item.Phone.ToString() };
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
