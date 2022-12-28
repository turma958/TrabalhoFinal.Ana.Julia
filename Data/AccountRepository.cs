using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaCredit.UI.Domain;
using Bogus;

namespace AdaCredit.UI.Data
{
    public class AccountRepository
    {
        private static List<Account> _accounts = new List<Account>();
        public static Account GetNewUnique()
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
