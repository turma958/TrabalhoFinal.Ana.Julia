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
            System.Console.WriteLine("Nome: ");
            string name = Console.ReadLine();

            System.Console.WriteLine("CPF (somente números): ");
            string document = Console.ReadLine();

            var employee = new Employee(name, document);
            
            Console.WriteLine("\n---------- * ----------\n");

            var repository = new EmployeeRepository();
            var result = repository.AddEmployee(employee);

            if (result)
            {
                Console.WriteLine("Funcionário adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha ao cadastrar novo funcionário.");
            }
            Console.ReadKey();
        }
    }
}
