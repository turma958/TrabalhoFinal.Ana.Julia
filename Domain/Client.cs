using Bogus;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus.DataSets;
using CsvHelper.Configuration;

namespace AdaCredit.UI.Domain
{
    public sealed class Client
    {
        public string Name { get; set; }
        public long Document { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public Account Account { get; private set; } = null;

        public Client(string name, long document, string dateOfBirth, string address)
        {
            Name = name;
            Document = document;
            DateOfBirth = dateOfBirth;
            Address = address;
        }
        public Client(string name, long document, string dateOfBirth, string address, Account account)
        {
            Name = name;
            Document = document;
            DateOfBirth = dateOfBirth;
            Address = address; 
            Account = account;
        }
    }
}