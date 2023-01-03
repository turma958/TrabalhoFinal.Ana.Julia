using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.Domain
{
    public class Transactions
    {
        public int SourceBank;
        public int SourceBranch;
        public int SourceAccountNumber;

        public int DestinationBank;
        public int DestinationBranch;
        public int DestinationAccountNumber;

        public string Type;
        public int Direction;
        public decimal Value;

        public Transactions(int sourceBank, int sourceBranch, int sourceAccountNumber, int destinationBank, int destinationBranch, int destinationAccountNumber, string type, int direction, decimal value)
        {
            SourceBank = sourceBank;
            SourceBranch = sourceBranch;
            SourceAccountNumber = sourceAccountNumber;
            DestinationBank = destinationBank;
            DestinationBranch = destinationBranch;
            DestinationAccountNumber = destinationAccountNumber;
            Type = type;
            Direction = direction;
            Value = value;
        }
    }
}
