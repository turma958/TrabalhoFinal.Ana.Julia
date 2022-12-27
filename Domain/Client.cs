using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.Console.Domain
{
    internal class Client
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string BirthDate { get; set; }
        public string Telephone { get; set; }

        public Client(string name, string document, string birthdate, string telephone)
        {
            Name = name;
            Document = document;
            BirthDate = birthdate;
            Telephone = telephone;
        }

        //public string GetName()
        //{
        //    return this.Name;
        //}

        
    }
}
