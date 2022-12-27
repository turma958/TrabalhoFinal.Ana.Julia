using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaCredit.Console.Domain;

namespace AdaCredit.Console.UseCases
{
    public static class AddNewClient
    {
        public static void Execute()
        {
            System.Console.WriteLine("Nome: ");
            string name = System.Console.ReadLine();
            
            System.Console.Write("CPF (somente números): ");
            long document = long.Parse(System.Console.ReadLine());
            
            //System.Console.Write("Data de nascimento (somente números): ");
            //string birthDate = System.Console.ReadLine();
            
            //System.Console.Write("Telefone (somente números): ");
            //string telephone = System.Console.ReadLine();

            Client client = new Client(name, document);

        }
    }
}
