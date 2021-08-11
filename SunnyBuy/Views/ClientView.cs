using SunnyBuy.Services.UsersServices;
using System;

namespace SunnyBuy.Views
{
    public class ClientView
    {
        static Context.Context context = new Context.Context();

        ClientService clientService = new ClientService(context);
        public void ShowNav()
        {
            Console.WriteLine("       ___________________________________________________________________________________________________\n");
            Console.WriteLine("       -----------------------------------------------  SunnyBuy -----------------------------------------\n");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            Console.Write("       Type your cpf: ");
            var cpf = Console.ReadLine();

            while (cpf.Length != 11)
            {
                Console.WriteLine("               Cpf number must have 11 characters: ");
                cpf = Console.ReadLine();
            }

            Console.Clear();
            ShowClientCpf(cpf);
        }

        public void ShowClientCpf(string cpf)
        {
            Console.WriteLine("       ___________________________________________________________________________________________________\n");
            Console.WriteLine("       -----------------------------------------------  SunnyBuy -----------------------------------------");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");
            Console.WriteLine("                                                        User Page                                         ");
            Console.WriteLine("       ___________________________________________________________________________________________________\n");

            clientService.GetClients(cpf).ForEach(
               client =>
               Console.WriteLine
               ($"              User name: { client.Name }\n\n" +
                $"              E mail: {client.Email}\n\n" +
                $"              Cpf: {client.Cpf}\n\n" +
                $"              Address: {client.Address}\n\n" +
                $"              Phone: {client.Phone}\n\n")
               );
        }
    }
}
