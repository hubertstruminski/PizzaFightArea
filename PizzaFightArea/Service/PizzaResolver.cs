using PizzaFightArea.Model;
using PizzaFightArea.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFightArea.Service
{
    public class PizzaResolver
    {
        private MainView mainView;
        private PizzaInitializator pizzaInitializator;

        public PizzaResolver()
        {
            mainView = new MainView();
            pizzaInitializator = new PizzaInitializator();
        }

        public int ChooseOptionInMainMenu()
        {
            int option = -1;
            do
            {
                mainView.ShowMainMenu();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException exception)
                {
                    mainView.ShowOptionChooseError();
                }
            } while (option != 1 && option != 2 && option != 3 && option != 4);
            return option;
        }

        public void SwitchToDestinationOption(int option)
        {
            switch(option)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    ManageStatistics(new List<Statistic>());
                    break;
                case 4:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public void ManageStatistics(List<Statistic> statistics)
        {
            foreach(Statistic statistic in statistics)
            {
                Console.WriteLine(statistic.ToString());
            }
        }
        
        public void Manage1VsComputer()
        {
            mainView.ShowInputNickCommand();
            string name = Console.ReadLine();

            Random random = new Random();
            Statistic statistic = new Statistic(name, 0);

            for(int i=0; i<pizzaInitializator.pizzas.Count / 2; i++)
            {
                int randomIndex1 = random.Next(0, pizzaInitializator.pizzas.Count);
                int randomIndex2 = random.Next(0, pizzaInitializator.pizzas.Count);

                Pizza myPizza = pizzaInitializator.pizzas[randomIndex1];
                Pizza computerPizza = pizzaInitializator.pizzas[randomIndex2];

                myPizza.ToString(name);
                computerPizza.ToString("Computer");

                if()
            }
        }
    }
}
