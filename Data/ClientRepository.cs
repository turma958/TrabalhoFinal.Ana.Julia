using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdaCredit.Console.Domain;

namespace AdaCredit.Console.Data
{
    public class ClientRepository
    {
        private List<Client> clients = new List<Client>();
        


        public Client GetByAccountNumber(string accountNumber)
        {

        }

        public void Save(Client client)
        {
            // encontra o cliente na lista e atualiza
            // salvar a lista toda no arquivo
        }
    }
}
