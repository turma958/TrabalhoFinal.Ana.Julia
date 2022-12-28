using AdaCredit.UI.Data;
using AdaCredit.UI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.UseCases
{
    public static class DeactivateClientRegister
    {
        public static void Execute()
        {
            System.Console.Write("CPF (somente números): ");
            string document = Console.ReadLine();

            Console.WriteLine("\n---------- * ----------\n");

            var repository = new ClientRepository();
            var result = repository.DeactivateClient(document);

            string message = "Operação realizada com sucesso!";

            if (!result)
                message = "Não foi possível realizar a operação.";

            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
