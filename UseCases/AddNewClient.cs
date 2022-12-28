using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaCredit.UI.Data;
using AdaCredit.UI.Domain;

namespace AdaCredit.UI.UseCases
{
    public static class AddNewClient
    {
        public static void Execute()
        {
            System.Console.WriteLine("Nome: ");
            string name = Console.ReadLine();
            
            System.Console.Write("CPF (somente números): ");
            string document = Console.ReadLine();

            var client = new Client(name, document);

            Console.WriteLine("\n---------- * ----------\n");

            var repository = new ClientRepository();
            var result = repository.AddClient(client);

            if (result)
            {
                Console.WriteLine("Cliente adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao cadastrar novo cliente.");
            }
            Console.ReadKey();
        }
    }
}
