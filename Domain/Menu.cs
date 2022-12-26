using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCredit.Console.Domain
{
    internal static class Menu
    {
        public static void Show()
        {
            var subMenu = new ConsoleMenu(args, level: 1)
                .Add("Sub_One", () => SomeAction("Sub_One"))
                .Add("Sub_Two", () => SomeAction("Sub_Two"))
                .Add("Sub_Three", () => SomeAction("Sub_Three"))
                .Add("Sub_Four", () => SomeAction("Sub_Four"))
                .Add("Sub_Close", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = true;
                    config.Title = "Submenu";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                });

            var menu = new ConsoleMenu(args, level: 0)
                .Add("One", () => SomeAction("One"))
                .Add("Two", () => SomeAction("Two"))
                .Add("Three", () => SomeAction("Three"))
                .Add("Sub", subMenu.Show)
                .Add("Change me", (thisMenu) => thisMenu.CurrentItem.Name = "I am changed!")
                .Add("Close", ConsoleMenu.Close)
                .Add("Action then Close", (thisMenu) => { SomeAction("Close"); thisMenu.CloseMenu(); })
                .Add("Exit", () => Environment.Exit(0))
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = true;
                    config.Title = "Main menu";
                    config.EnableWriteTitle = true;
                    config.EnableBreadcrumb = true;
                });
        }
    }
}
