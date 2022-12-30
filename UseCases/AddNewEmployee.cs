using AdaCredit.UI.Data;
using AdaCredit.UI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.UseCases
{
    public static class AddNewEmployee
    {
        public static void Execute()
        {
            Console.WriteLine("\n----- Adicionar novo funcionário -----\n");

            Console.WriteLine("Nome: ");
            string name = Console.ReadLine();

            Console.WriteLine("CPF (somente números): ");
            string document = Console.ReadLine();

            var employee = new Employee(name, document);
            var repository = new EmployeeRepository();

            

            Console.WriteLine("\n---------- * ----------\n");

            var result = repository.AddEmployee(employee);

            if (result)
            {
                Console.WriteLine("\n\nFuncionário adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("\n\nFalha ao cadastrar novo funcionário.");
            }
            Console.ReadKey();
        }
    }
}
