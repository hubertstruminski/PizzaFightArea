using PizzaFightArea.Model;
using PizzaFightArea.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaFightArea.Service
{
    public class PizzaResolver
    {
        private MainView mainView;
        private PizzaInitializator pizzaInitializator;

        private int playerWins = 0;
        private int playerLosts = 0;
        private int playerDeadHeats = 0;

        private int secondPlayerWins = 0;
        private int secondPlayerLosts = 0;

        private bool isPlayerWinner = false;

        private static List<Statistic> statistics;
        private Random random;

        public PizzaResolver()
        {
            mainView = new MainView();
            pizzaInitializator = new PizzaInitializator();
            statistics = new List<Statistic>();
            random = new Random(); 
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
                    Manage1VsComputer();
                    break;
                case 2:
                    Manage1Vs1();
                    break;
                case 3:
                    ManageStatistics(statistics);
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
            if(statistics.Count != 0)
            {
                List<Statistic> lists = statistics.OrderByDescending(i => i.Score).ToList();
                foreach (Statistic statistic in lists)
                {
                    Console.WriteLine(statistic.ToString());
                }
            }
            else
            {
                mainView.showNoAvailableStatistics();
            }
            
        }
        
        public void Manage1VsComputer()
        {
            mainView.ShowInputNickCommand();
            string name = Console.ReadLine();

            Statistic myStatistics = new Statistic(name, 0);
            Statistic computerStatistics = new Statistic("Computer", 0);

            RestartScores();

            for(int i=0; i<10; i++)
            {
                ManageGameQueue(name, myStatistics, computerStatistics, "Computer");
            }
            mainView.ShowScores(name, playerWins, playerLosts,
                playerDeadHeats, "Computer", secondPlayerWins, secondPlayerLosts);

            checkThatPlayerExistInStatistics(myStatistics);
            checkThatPlayerExistInStatistics(computerStatistics);
        }

        public void Manage1Vs1()
        {
            mainView.ShowInputNickCommand();
            string firstName = Console.ReadLine();

            mainView.ShowInputNikCommandForSecondPlayer();
            string secondName = Console.ReadLine();

            Statistic firstPlayerStatistics = new Statistic(firstName, 0);
            Statistic secondPlayerStatistics = new Statistic(secondName, 0);

            RestartScores();

            for (int i = 0; i < 10; i++)
            {
                ManageGameQueue(firstName, firstPlayerStatistics, secondPlayerStatistics, secondName);
            }
            mainView.ShowScores(firstName, playerWins, playerLosts,
                playerDeadHeats, secondName, secondPlayerWins, secondPlayerLosts);

            checkThatPlayerExistInStatistics(firstPlayerStatistics);
            checkThatPlayerExistInStatistics(secondPlayerStatistics);
        }

        public void chooseWinner(string name, string secondNamePlayer)
        {
            if (isPlayerWinner)
            {
                mainView.ShowWinner(name);
            }
            else
            {
                mainView.ShowWinner(secondNamePlayer);
            }
        }

        public void computeAndAssignScore(Pizza myPizza, Pizza computerPizza,
                                            Statistic myStatistics, Statistic computerStatistics)
        {
            if (myPizza.Score > computerPizza.Score)
            {
                myStatistics.Score += myPizza.Score;
                isPlayerWinner = true;
                playerWins++;
                secondPlayerLosts++;
            }
            else if (myPizza.Score < computerPizza.Score)
            {
                computerStatistics.Score += computerPizza.Score;
                isPlayerWinner = false;
                playerLosts++;
                secondPlayerWins++;
            }
            else
            {
                mainView.ShowDeadHeat();
                playerDeadHeats++;
            }
        }

        public void ManageGameQueue(string name, Statistic myStatistics, Statistic computerStatistics, string secondNamePlayer)
        {
            int randomIndex1 = random.Next(0, pizzaInitializator.pizzas.Count);
            int randomIndex2 = random.Next(0, pizzaInitializator.pizzas.Count);

            Pizza myPizza = pizzaInitializator.pizzas[randomIndex1];
            Pizza computerPizza = pizzaInitializator.pizzas[randomIndex2];

            Console.WriteLine(myPizza.ToString(name));
            Console.WriteLine(computerPizza.ToString(secondNamePlayer));

            isPlayerWinner = false;
            computeAndAssignScore(myPizza, computerPizza, myStatistics, computerStatistics);
            chooseWinner(name, secondNamePlayer);

            mainView.ShowReadKeyForContinueGame();
            Console.ReadKey();
            Console.Clear();
        }

        public void checkThatPlayerExistInStatistics(Statistic statistic)
        {
            int index = statistics.FindIndex(s => s.Nick.Equals(statistic.Nick));
            if (index == -1)
            {
                statistics.Add(statistic);
            }
            else
            {
                Statistic returnedStatistic = statistics[index];
                returnedStatistic.Score += statistic.Score;
            }
        } 

        public void RestartScores()
        {
            playerWins = 0;
            playerLosts = 0;
            playerDeadHeats = 0;

            secondPlayerWins = 0;
            secondPlayerLosts = 0;
        }
    }
}
