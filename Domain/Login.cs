using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.Console.Domain
{
    internal static class Login
    {
        public static void Show()
        {
            bool loggedIn = false;

            do
            {
                System.Console.Clear();

                System.Console.Write("Usuário: ");
                string username = System.Console.ReadLine();

                System.Console.Write("Senha: ");
                string password = System.Console.ReadLine();

                // NECESSITA ALTERAR A LÓGICA DE COMPARAÇÃO DE SENHA AQUI

                if (username.Equals("user", StringComparison.InvariantCultureIgnoreCase)
                    && password.Equals("pass", StringComparison.CurrentCultureIgnoreCase))
                {
                    loggedIn = true;
                    break;
                }

                System.Console.WriteLine("Login não efetuado. Por favor, verifique as informações.");
                System.Console.ReadKey();

            } while (!loggedIn);

            System.Console.Clear();
            System.Console.WriteLine("Login efetuado com sucesso.");
            System.Console.ReadKey();
            System.Console.Clear();
        }
    }
}
