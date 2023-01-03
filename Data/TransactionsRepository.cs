using AdaCredit.UI.Domain;
using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.Data
{
    public class TransactionsRepository
    {
        private static List<Transactions> _transactions = new List<Transactions>();

        static TransactionsRepository()
        {
            try
            {
                string finalFolder = "Transactions";
                string mainPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), finalFolder);
                
                if (!Directory.Exists(mainPath))
                {
                    Directory.CreateDirectory(mainPath);
                    return;
                }

                var paths = Directory.EnumerateFiles(mainPath, "*.csv").ToList();

                foreach (var path in paths)
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false,
                    };
                    using (var reader = new StreamReader(path))
                    using (var csv = new CsvReader(reader, config))
                    {
                        csv.Read();
                        _transactions = csv.GetRecords<Transactions>().ToList();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            foreach (var transaction in _transactions)
            {
                Console.Write(transaction.Value);
            }
        }



    }
}
