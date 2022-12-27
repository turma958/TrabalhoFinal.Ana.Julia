using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.Domain
{
    public sealed class Client
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public Account Account { get; private set; } = null;

        public Client(string name, string document)
        {
            Name = name;
            Document = document;
            Account = null;
        }

        public Client(string name, string document, Account account)
        {
            Name = name;
            Document = document;
            Account = account;
        }
    }
}
