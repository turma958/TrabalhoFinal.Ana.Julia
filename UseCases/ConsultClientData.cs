using AdaCredit.UI.Data;
using AdaCredit.UI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.UseCases
{
    public static class ConsultClientData
    {
        public static void ExecuteByName()
        {

            System.Console.WriteLine("Nome completo: ");
            string name = Console.ReadLine();

            var repository = new ClientRepository();
            repository.GetByName(name);

            Console.ReadKey();
        }

        public static void ExecuteByDocument()
        {
            System.Console.WriteLine("CPF: ");
            string document = Console.ReadLine();

            var repository = new ClientRepository();
            repository.GetByDocument(document);

            Console.ReadKey();

        }
        public static void ExecuteByAccountNumber()
        {
            System.Console.WriteLine("Número da conta: ");
            string accountNumber = Console.ReadLine();

            System.Console.WriteLine("Agência: ");
            string branch = Console.ReadLine();


            var repository = new ClientRepository();
            repository.GetByAccountNumber(accountNumber, branch);

            Console.ReadKey();
        }
    }
}
