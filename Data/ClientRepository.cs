//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AdaCredit.Console.Domain;

//namespace AdaCredit.Console.Data
//{
//    internal class ClientRepository
//    {
//        public List<Client> clients = new List<Client>();

//        public bool AddClient()
//        {
//            System.Console.WriteLine("Nome: ");
//            string name = System.Console.ReadLine();
//            System.Console.Write("CPF (somente números): ");
//            string id = System.Console.ReadLine();
//            System.Console.Write("Data de nascimento (somente números): ");
//            string birthDate = System.Console.ReadLine();
//            System.Console.Write("Telefone (somente números): ");
//            string telephone = System.Console.ReadLine();

//            if (clients.Any(client => client.Document.Equals(id)))
//            {
//                System.Console("CPF já cadastrado.");
//            }

//        }
//        public Client GetByAccountNumber(string accountNumber)
//        {

//        }

//        public void Save(Client client)
//        {
//            // encontra o cliente na lista e atualiza
//            // salvar a lista toda no arquivo
//        }
//    }
//}
