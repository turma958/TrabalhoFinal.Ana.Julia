﻿using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTools;
using System.Diagnostics;
using AdaCredit.UI.UseCases;

namespace AdaCredit.UI.Domain
{
    internal static class Menu
    {
        public static void Show()
        {
            var subConsultData = new ConsoleMenu(Array.Empty<string>(), level: 2)
                .Add("Consultar por nome", ConsultClientData.ExecuteByName)
                .Add("Consultar por CPF", ConsultClientData.ExecuteByDocument)
                .Add("Consultar por número da conta", ConsultClientData.ExecuteByAccountNumber)
                .Add("Voltar", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = false;
                    config.Title = "Consultar dados do cliente";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => System.Console.WriteLine(string.Join(" / ", titles));
                    config.SelectedItemBackgroundColor = ConsoleColor.DarkBlue;
                    config.SelectedItemForegroundColor = ConsoleColor.White;
                });

            var subClient = new ConsoleMenu(Array.Empty<string>(), level: 1)
                .Add("Cadastrar novo cliente", AddNewClient.Execute)
                .Add("Consultar dados do cliente", subConsultData.Show)
                //.Add("Alterar cadastro do cliente", () => ChangeClientData())
                //.Add("Desativar cadastro do cliente", () => CancelClientRegister())
                .Add("Voltar", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = false;
                    config.Title = "Clientes";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => 
                        System.Console.WriteLine(string.Join(" / ", titles));
                    config.SelectedItemBackgroundColor = ConsoleColor.DarkBlue;
                    config.SelectedItemForegroundColor = ConsoleColor.White;
                });

            //var subEmployee = new ConsoleMenu(Array.Empty<string>(), level: 1)
            //    .Add("Cadastrar novo funcionário", () => AddNewEmployee())
            //    .Add("Consultar dados do funcionário", () => ConsultEmployeeData())
            //    .Add("Alterar cadastro do funcionário", () => ChangeEmployeeData())
            //    .Add("Desativar cadastro do funcionário", () => CancelEmployeeRegister())
            //    .Add("Voltar", ConsoleMenu.Close)
            //    .Configure(config =>
            //    {
            //        config.Selector = "--> ";
            //        config.EnableFilter = false;
            //        config.Title = "Funcionários";
            //        config.EnableBreadcrumb = true;
            //        config.WriteBreadcrumbAction = titles => System.Console.WriteLine(string.Join(" / ", titles));
            //        config.SelectedItemBackgroundColor = ConsoleColor.DarkBlue;
            //        config.SelectedItemForegroundColor = ConsoleColor.White;
            //    });

            //var subTransactions = new ConsoleMenu(Array.Empty<string>(), level: 1)
            //    .Add("Processar transações (Reconciliação Bancária)", () => ProcessTransactions())
            //    .Add("Voltar", ConsoleMenu.Close)
            //    .Configure(config =>
            //    {
            //        config.Selector = "--> ";
            //        config.EnableFilter = false;
            //        config.Title = "Transações";
            //        config.EnableBreadcrumb = true;
            //        config.WriteBreadcrumbAction = titles => System.Console.WriteLine(string.Join(" / ", titles));
            //        config.SelectedItemBackgroundColor = ConsoleColor.DarkBlue;
            //        config.SelectedItemForegroundColor = ConsoleColor.White;
            //    });

            //var subReports = new ConsoleMenu(Array.Empty<string>(), level: 1)
            //    .Add("Exibir clientes ativos e saldos", () => CheckActiveClients())
            //    .Add("Exibir clientes inativos", () => CheckInactiveClients())
            //    .Add("Exibir funcionários ativos e último login", () => CheckActiveEmployees())
            //    .Add("Exibir transações com erro", () => CheckErrorsTransactions())
            //    .Add("Voltar", ConsoleMenu.Close)
            //    .Configure(config =>
            //    {
            //        config.Selector = "--> ";
            //        config.EnableFilter = false;
            //        config.Title = "Relatórios";
            //        config.EnableBreadcrumb = true;
            //        config.WriteBreadcrumbAction = titles => System.Console.WriteLine(string.Join(" / ", titles));
            //        config.SelectedItemBackgroundColor = ConsoleColor.DarkBlue;
            //        config.SelectedItemForegroundColor = ConsoleColor.White;
            //    });

            var menu = new ConsoleMenu(Array.Empty<string>(), level: 0)
                .Add("Clientes", subClient.Show)
                //.Add("Funcionários", subEmployee.Show)
                //.Add("Transações", subTransactions.Show)
                //.Add("Relatórios", subReports.Show)
                .Add("Exit", () => Environment.Exit(0))
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = false;
                    config.Title = "Menu principal";
                    config.EnableWriteTitle = false;
                    config.EnableBreadcrumb = true;
                    config.SelectedItemBackgroundColor = ConsoleColor.DarkBlue;
                    config.SelectedItemForegroundColor = ConsoleColor.White;
                });

            menu.Show();
        }

         
    }
}
