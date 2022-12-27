using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace AdaCredit.UI.Domain
{
    public sealed class Account
    {
        public string Number { get; private set; }
        public string Branch { get; private set; }

        public Account()
        {
            Number = new Faker().Random.ReplaceNumbers("#####-#");
            Branch = "0001";
        }

        public Account(string number)
        {
            Number = number;
            Branch = "0001";
        }
    }
}
