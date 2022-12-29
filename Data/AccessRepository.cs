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
    public class AccessRepository
    {
        private static List<Access> _accessList = new List<Access>();

        static AccessRepository()
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = "AccessList.txt";
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
                        _accessList.Add(new Access(record[0], DateTime.Parse(record[1])));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool FirstLogin(string user)
        {
            var result = _accessList.Any(a => a.User == user);

            if (result)
                return false;

            return true;
        }
    }
}
