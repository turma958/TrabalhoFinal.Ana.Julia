using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.Domain
{
    public sealed class Employee
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string User { get; set; } = "user";
        public string HashedPassword { get; set; }
        public string Salt { get; private set; }

        public bool IsActive { get; set; } = true;
        public DateTime LastAccess { get; set; }

        public Employee(string name, string document)
        {
            Name = name;
            Document = document;
            User = "user";
            HashedPassword = "pass";
        }

        public Employee(string name, string document, string user, string hashedPassword, string salt)
        {
            Name = name;
            Document = document;
            User = user;
            HashedPassword = hashedPassword;
            Salt = salt;
        }

        public void Login()
        {
            // Fazer a tela de login mandar um recado para o login do empregado
            // O recado vai adicionar o acesso na lista do cliente
            // Se for o primeiro acesso vai criar a troca de senha e usuario
            // Fazer uma lista que le na criação do login se aquele usuario ja existe (isso nao vai possibilitar a criação de dois funcionarios ao mesmo tempo) 
        }
    }
}
