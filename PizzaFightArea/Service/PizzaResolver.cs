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

        public PizzaResolver()
        {
            mainView = new MainView();
        }

        public int chooseOptionInMainMenu()
        {
            int option = -1;

            do
            {
                mainView.showMainMenu();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException exception)
                {
                    mainView.showOptionChooseError();
                }
            } while (option != 1 && option != 2 && option != 3 && option != 4);
            return option;
        }

        public void switchToDestinationOption(int option)
        {
            switch(option)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    manageStatistics(new List<Statistic>());
                    break;
                case 4:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public void manageStatistics(List<Statistic> statistics)
        {
            foreach(Statistic statistic in statistics)
            {
                Console.WriteLine(statistic.ToString());
            }
        }
        
    }
}
