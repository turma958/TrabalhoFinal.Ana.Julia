using AdaCredit.UI.Data;
using AdaCredit.UI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.UseCases
{
    public static class ChangeClientData
    {
        public static void Execute(int index)
        {
            Console.WriteLine("\n----- Alterar dados do cliente -----\n");

            System.Console.WriteLine("CPF da conta: ");
            string document = Console.ReadLine();

            string newData = "";

            if (index == 1)
            {
                Console.WriteLine("Nome a atualizar: ");
                newData = Console.ReadLine();

            } else if (index == 2)
            {
                Console.WriteLine("CPF a atualizar: ");
                newData = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Uma nova conta será gerada.");
            }

            Console.WriteLine("\n---------- * ----------\n");

            var repository = new ClientRepository();
            var result = repository.ChangeData(document, index, newData);

            string message = "Alteração finalizada com sucesso!";

            if (!result)
                message = "Não foi possível alterar o cadastro. Verifique os dados ou cadastre um cliente novo.";
            
            Console.WriteLine(message);
            Console.ReadKey() ;
        }
    }
}
