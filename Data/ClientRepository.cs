using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AdaCredit.UI.Domain;
using Bogus.DataSets;
using CsvHelper;
using CsvHelper.Configuration;
using System.Formats.Asn1;
using CsvHelper.Configuration.Attributes;
using System.Xml.Linq;

namespace AdaCredit.UI.Data
{
    public class ClientRepository
    {
        private static List<Client> _clients = new List<Client>();

         static ClientRepository()
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = "Clients.txt";
                string filePath = Path.Combine(path, fileName);

                if (!File.Exists(filePath))
                {
                    return;
                }

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };
                
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvParser(reader, config))
                {

                    csv.Read();
                    while (csv.Read())
                    {
                        var record = csv.Record;
                        _clients.Add(new Client(record[0], record[1], new Account(record[2])));
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public bool AddClient(Client client)
        {
            if (_clients.Any(c => c.Document.Equals(client.Document)))
            {
                System.Console.WriteLine("Cliente já cadastrado.");
                System.Console.ReadKey();

                return false;
            }

            _clients.Add(new Client(client.Name, client.Document, AccountRepository.GetNewUnique()));
            
            Save();
            
            return true;
        }
        public void Save()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "Clients.txt";

            string filePath = Path.Combine(path, fileName);

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(_clients);
            }
        }
        public bool GetInfos(int index, string info, string secondInfo = "")
        {
            Client client;
            string situation;

            if (index == 1)
            {
                var clients = from c in _clients
                    where c.Name == info
                    select c;

                if (clients.Equals(Enumerable.Empty<Client>()))
                    return false;

                foreach (var c in clients)
                {
                    situation = "Desativada";
                    if (c.IsActive)
                        situation = "Ativada";
                    Console.Write($"Nome: {c.Name}\nCPF: {c.Document}\nNúmero da conta: {c.Account.Number}\nAgência: {c.Account.Branch}\nSituação:{situation}\n");
                }
                return true;
            } 
            else if (index == 2)
            {
                client = _clients.FirstOrDefault(c => c.Document == info);
            }
            else
            {
                client = _clients.FirstOrDefault(c => c.Account.Number == info && c.Account.Branch == secondInfo);
            }

            if (client == null)
                return false;

            situation = "Desativada";
            if (client.IsActive)
                situation = "Ativada";
            Console.Write($"Nome: {client.Name}\nCPF: {client.Document}\nNúmero da conta: {client.Account.Number}\nAgência: {client.Account.Branch}\nSituação:{situation}\n");

            return true;
        }
        public bool ChangeData(string document,int index,  string newData)
        {
            var client = _clients.FirstOrDefault(c => c.Document == document);

            if (client==null) 
                return false;

            if (index == 1)
            {
                client.Name = newData;
            } else if (index == 2)
            {
                bool isBeingUsed= _clients.Any(c => c.Document == newData);
                if (isBeingUsed)
                    return false;

                client.Document = newData;
            }
            //else
            //{
            //    _clients.Add(new Client(client.Name, document, AccountRepository.GetNewUnique()));
            //}

            Save();
            return true;
        }

        public bool DeactivateClient(string document)
        {
            var client = _clients.FirstOrDefault(c => c.Document == document);

            if(client==null) 
                return false;

            client.IsActive = false;

            Save();
            return true;
        }

    }
}
