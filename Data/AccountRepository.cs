using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaCredit.Console.Domain;
using Bogus;

namespace AdaCredit.Console.Data
{
    public class AccountRepository
    {
        private List<Account> _accounts = new List<Account>();
        public Account GetNewUnique()
        {
            var exists = false;
            var accountNumber = "";

            do
            {
                accountNumber = new Faker().Random.ReplaceNumbers("#####-#");
                exists = _accounts.Any(a => a.Number.Equals(accountNumber));

            } while (exists);

            return new Account(accountNumber);
        }
    }
}
