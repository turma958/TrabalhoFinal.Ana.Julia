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
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.Document).Name("Document");
            Map(m => m.DateOfBirth).Name("DateOfBirth");
            Map(m => m.Address).Name("Address");
            Map(m => m.Account.Number).Name("Number");
            Map(m => m.Account.Branch).Name("Branch");
            Map(m => m.Account.Balance).Name("Balance");
            Map(m => m.IsActive).Name("IsActive");
        }
    }
    public sealed class Client
    {
        public string Name { get; set; }
        public long Document { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public Account Account { get; private set; } = null;
        public bool IsActive { get; set; } = true;

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
        public Client(string name, long document, string dateOfBirth, string address, Account account, bool isActive)
        {
            Name = name;
            Document = document;
            DateOfBirth = dateOfBirth;
            Address = address; 
            Account = account;
            IsActive = isActive;
        }
    }
}