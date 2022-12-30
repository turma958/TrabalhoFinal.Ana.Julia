using AdaCredit.UI.Domain;
using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;
using Bogus.DataSets;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using AdaCredit.UI.UseCases;
using System.Xml.Linq;

namespace AdaCredit.UI.Data
{
    public class EmployeeRepository
    {
        private static List<Employee> _employees = new List<Employee>();
        static EmployeeRepository()
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fileName = "Employees.txt";
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
                        _employees.Add(new Employee(record[0], record[1], record[2], 
                            record[3], record[4], Convert.ToBoolean(record[5]),
                            DateTime.ParseExact(record[6], "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture)));
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public bool FirstAccess()
        {
            if(_employees.Any())
                return false;

            return true;
        }

        public void SaveAccess(string username)
        {
            var employee = _employees.FirstOrDefault(e => e.User == username);

            employee.LastAccess = DateTime.Now;

            Save();
        }
        public bool AddEmployee(Employee employee)
        {
            if (_employees.Any(e => e.Document.Equals(employee.Document)))
            {
                System.Console.WriteLine("Funcionário já cadastrado.");
                System.Console.ReadKey();

                return false;
            }

            bool flag;
            string user;
            do
            {
                Console.Write("\nUsuário: ");
                user = Console.ReadLine();
                flag = _employees.Any(e => e.User == user);
            } while (flag);
            
            string hashedPassword = "";
            string salt ="";
            do
            {
                Console.Write("\nNova senha: ");
                var firstTry = EnterPassword.Execute();

                Console.Write("\nDigite novamente a nova senha: ");
                var secondTry = EnterPassword.Execute();

                flag = firstTry == secondTry;

                if (flag)
                {
                    hashedPassword = PasswordEncrypting.GenerateHash(firstTry, out salt);
                    break;
                }

                Console.WriteLine("\nSenhas não coincidem. Tente novamente.\n");
            } while (!flag);

            _employees.Add(new Employee(employee.Name, employee.Document, user, hashedPassword, salt));

            Save();
            return true;
        }
        public void Save()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "Employees.txt";

            string filePath = Path.Combine(path, fileName);

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(_employees);
            }
        }

        public bool IsLoginValid(string user, string password)
        {
            var employee = _employees.FirstOrDefault(e => e.User == user);

            if (employee == null)
                return false;

            var hashedPassword = PasswordEncrypting.Hash(password, employee.Salt);

            if (_employees.Any(e => e.User == user && hashedPassword== e.HashedPassword))
                return true;

            return false;
        }
        public bool ChangeUsername(string document)
        {
            var employee = _employees.FirstOrDefault(e => e.Document == document);

            if (employee == null)
                return false;

            var flag = false;
            string user;
            do
            {
                Console.Write("\nNovo usuário: ");
                user = Console.ReadLine();
                flag = _employees.Any(e => e.User == user);
            } while (flag);

            employee.User = user;
            Save();

            return true;
        }
        public bool ChangePassword(string document)
        {
            var employee = _employees.FirstOrDefault(e => e.Document == document);

            if (employee == null)
                return false;

            var flag = false;
            string hashedPassword="";
            do
            {
                Console.Write("\nNova senha: ");
                var firstTry = EnterPassword.Execute();

                Console.Write("\nDigite novamente a nova senha: ");
                var secondTry = EnterPassword.Execute();

                flag = firstTry == secondTry;
                
                if (flag)
                {
                    hashedPassword = PasswordEncrypting.GenerateHash(firstTry, out var salt);
                    employee.HashedPassword = hashedPassword;
                    employee.Salt = salt;
                    break;
                }

                Console.WriteLine("\nSenhas não coincidem. Tente novamente.\n");
            } while (!flag);

            Save();
            return true;
        }


        //public bool GetInfos(int index, string info, string secondInfo = "")
        //{
        //    Client client;
        //    string situation;

        //    if (index == 1)
        //    {
        //        var clients = from c in _clients
        //                      where c.Name == info
        //                      select c;

        //        if (clients.Equals(Enumerable.Empty<Client>()))
        //            return false;

        //        foreach (var c in clients)
        //        {
        //            situation = "Desativada";
        //            if (c.IsActive)
        //                situation = "Ativada";
        //            Console.Write($"Nome: {c.Name}\nCPF: {c.Document}\nNúmero da conta: {c.Account.Number}\nAgência: {c.Account.Branch}\nSituação:{situation}\n");
        //        }
        //        return true;
        //    }
        //    else if (index == 2)
        //    {
        //        client = _clients.FirstOrDefault(c => c.Document == info);
        //    }
        //    else
        //    {
        //        client = _clients.FirstOrDefault(c => c.Account.Number == info && c.Account.Branch == secondInfo);
        //    }

        //    if (client == null)
        //        return false;

        //    situation = "Desativada";
        //    if (client.IsActive)
        //        situation = "Ativada";
        //    Console.Write($"Nome: {client.Name}\nCPF: {client.Document}\nNúmero da conta: {client.Account.Number}\nAgência: {client.Account.Branch}\nSituação: {situation}\n");

        //    return true;
        //}
        //public bool ChangeData(string document, int index, string newData)
        //{
        //    var client = _clients.FirstOrDefault(c => c.Document == document);

        //    if (client == null)
        //        return false;

        //    if (index == 1)
        //    {
        //        client.Name = newData;
        //    }
        //    else if (index == 2)
        //    {
        //        bool isBeingUsed = _clients.Any(c => c.Document == newData);
        //        if (isBeingUsed)
        //            return false;

        //        client.Document = newData;
        //    }
        //    else
        //    {
        //        var position = _clients.IndexOf(client);
        //        _clients[position] = new Client(client.Name, document, AccountRepository.GetNewUnique());
        //        Console.WriteLine($"A nova conta é {_clients[position].Account.Number}.");
        //    }

        //    Save();
        //    return true;
        //}

        //public bool DeactivateClient(string document)
        //{
        //    var client = _clients.FirstOrDefault(c => c.Document == document);

        //    if (client == null)
        //        return false;

        //    if (client.IsActive)
        //    {
        //        Console.WriteLine("A conta está ativa. Deseja desativar? (s/n)");
        //        var answer = Console.ReadLine();
        //        if (answer == "n")
        //            return false;

        //        client.IsActive = false;
        //    }
        //    else
        //    {
        //        Console.WriteLine("A conta está desativada. Deseja ativar? (s/n)");
        //        var answer = Console.ReadLine();
        //        if (answer == "n")
        //            return false;

        //        client.IsActive = true;
        //    }

        //    Save();
        //    return true;
        //}
    }
}
