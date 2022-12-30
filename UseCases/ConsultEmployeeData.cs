using AdaCredit.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.UseCases
{
    public class ConsultEmployeeData
    {
        public static void Execute(int index)
        {
            Console.WriteLine("\n----- Consultar dados do funcionário -----\n");
            string info;

            if (index == 1)
            {
                Console.WriteLine("Nome completo: ");
                info = Console.ReadLine();
            }
            else if (index == 2)
            {
                Console.WriteLine("CPF (somente números): ");
                info = Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Usuário: ");
                info = Console.ReadLine();
            }

            Console.WriteLine("\n---------- * ----------\n");
            var repository = new EmployeeRepository();
            var result = repository.GetInfos(index, info);

            if (!result)
                Console.WriteLine(
                    "Não foi possível encontrar o cadastro. Verifique os dados ou cadastre um funcionário novo.");

            Console.ReadKey();
        }
    }
}
