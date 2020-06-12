using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFightArea.View
{
    public class MainView
    {
        public void ShowMainMenu()
        {
            Console.WriteLine("Pizza Fight Area");
            Console.WriteLine("----------------");
            Console.WriteLine("1. New game - 1 vs Computer");
            Console.WriteLine("2. New game - 1 vs 1");
            Console.WriteLine("3. Statistics");
            Console.WriteLine("4. Exit");
            Console.WriteLine("----------------");
            Console.Write("Option: ");
        }

        public void ShowOptionChooseError()
        {
            Console.WriteLine("It's not a number.");
        }

        public void ShowInputNickCommand()
        {
            Console.Write("\nInput your Name: ");
        }
    }
}
