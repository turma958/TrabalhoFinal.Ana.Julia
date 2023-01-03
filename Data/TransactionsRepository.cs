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

                var filteredFiles = Directory
                    .GetFiles(mainPath, "*.*")
                    .Where(file => !file.EndsWith("-completed.csv"))
                    .ToList();

                foreach (var file in filteredFiles)
                {
                    List<Transactions> records;
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false,
                    };
                    using (var reader = new StreamReader(file))
                    using (var csv = new CsvReader(reader, config))
                    {

                        records = csv.GetRecords<Transactions>().ToList();
                    }

                    foreach (var record in records)
                    {
                        _transactions.Add(record);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



    }
}
