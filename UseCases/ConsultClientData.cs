﻿using AdaCredit.UI.Data;
using AdaCredit.UI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.UI.UseCases
{
    public static class ConsultClientData
    {
        public static void Execute(int index)
        {

            Console.WriteLine("\n----- Consultar dados do cliente -----\n");
            string info;
            string secondInfo="";

            if (index == 1)
            {
                Console.WriteLine("Nome completo: ");
                info = Console.ReadLine();
            } 
            else if (index == 2)
            {
                Console.WriteLine("CPF (somente números): ");
                info = Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Número da conta: ");
                info = Console.ReadLine();

                Console.WriteLine("Número da agência: ");
                secondInfo = Console.ReadLine();
            }

            Console.WriteLine("\n---------- * ----------\n");
            var repository = new ClientRepository();
            var result = repository.GetInfos(index, info, secondInfo);

            if(!result)
                Console.WriteLine("Não foi possível encontrar o cadastro. Verifique os dados ou cadastre um cliente novo.");

            Console.ReadKey();
        }
    }
}
