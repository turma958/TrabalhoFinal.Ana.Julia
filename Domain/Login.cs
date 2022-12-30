using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaCredit.UI.Data;

namespace AdaCredit.UI.Domain
{
    internal static class Login
    {
        public static void Show()
        {
            bool loggedIn = false;
            var repository = new EmployeeRepository();
            string username;
            
            do
            {
                System.Console.Clear();

                System.Console.Write("Usuário: ");
                username = Console.ReadLine();

                System.Console.Write("Senha: ");
                var cleanPassword = string.Empty;
                ConsoleKey key;
                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;

                    if (key == ConsoleKey.Backspace && cleanPassword.Length > 0)
                    {
                        Console.Write("\b \b");
                        cleanPassword = cleanPassword[0..^1];
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Console.Write("*");
                        cleanPassword += keyInfo.KeyChar;
                    }
                } while (key != ConsoleKey.Enter);

                var result = repository.IsLoginValid(username, cleanPassword);

                if (result)
                {
                    loggedIn = true;
                    break;
                }

                System.Console.WriteLine("\n\nLogin não efetuado. Por favor, verifique as informações.");
                System.Console.ReadKey();

            } while (!loggedIn);

            System.Console.Clear();

            repository.IsFirstAccess(username);

            System.Console.Clear();
            System.Console.WriteLine("Login efetuado com sucesso.");
            System.Console.ReadKey();
            System.Console.Clear();
        }
    }
}
