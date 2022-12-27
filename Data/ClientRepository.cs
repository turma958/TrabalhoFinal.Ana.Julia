using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AdaCredit.UI.Domain;
using Bogus.DataSets;
using CsvHelper;
using CsvHelper.Configuration;

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
                if (!File.Exists(fileName))
                {
                    string[] header = { "Name", "Document", "Number", "Branch" };
                    using StreamWriter file = new StreamWriter(filePath);
                        file.WriteLine(header);

                    file.Close();
                }
                
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<Client>();
                        _clients.Add(record);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public bool Add(Client client)
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
        public static void Save()
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
    }
}
