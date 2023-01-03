using AdaCredit.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.UseCases
{
    public class ChangeEmployeeData
    {
        public static void Execute(int index)
        {
            Console.WriteLine("\n----- Alterar dados do funcionário -----\n");

            Console.Write("CPF da conta: ");
            long document = long.Parse(Console.ReadLine());

            string newData = "";

            Console.WriteLine("\n---------- * ----------\n");

            switch (index)
            {
                case 1:
                    Console.Write("\nNome a atualizar: ");
                    newData = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("\nCPF a atualizar: ");
                    newData = Console.ReadLine();
                    break;
            }

            var repository = new EmployeeRepository();
            var result = repository.ChangeData(document, index, newData);

            string message = "\n\nAlteração finalizada com sucesso!";

            if (!result)
                message = "\n\nNão foi possível alterar o cadastro. Verifique os dados ou cadastre um cliente novo.";

            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
