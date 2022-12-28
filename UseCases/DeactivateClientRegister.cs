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
            
            var repository = new ClientRepository();
            var result = repository.DeactivateClient(document);

            string message = "Conta desativada com sucesso!";

            if (!result)
                message = "Não foi possível encontrar o cadastro. Verifique os dados ou cadastre um cliente novo.";

            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
