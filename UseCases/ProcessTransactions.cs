using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaCredit.UI.Data;

namespace AdaCredit.UI.UseCases
{
    public class ProcessTransactions
    {
        public static void Execute()
        {
            var repository = new TransactionsRepository();
        }
    }
}
