using PizzaFightArea.Model;
using PizzaFightArea.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaFightArea.Service
{
    /// <summary>
    ///     The class which is responsible for management functionalities
    /// </summary>
    public class PizzaResolver
    {
        private MainView mainView;
        private PizzaInitializator pizzaInitializator;

        /// <summary>
        ///     The property describes how often first player has been won.
        /// </summary>
        private int playerWins = 0;

        /// <summary>
        ///     The property describes number of losts for first player.
        /// </summary>
        private int playerLosts = 0;

        /// <summary>
        ///     The property describes number of dead heats for first player.
        /// </summary>
        private int playerDeadHeats = 0;

        /// <summary>
        ///     The property describes number of wins for second player
        /// </summary>
        private int secondPlayerWins = 0;

        /// <summary>
        ///     The property describes number of losts for second player.
        /// </summary>
        private int secondPlayerLosts = 0;

        /// <summary>
        ///     The property is flag which indicates who is winner.
        /// </summary>
        private bool isPlayerWinner = false;

        /// <summary>
        ///     The property which stores data about statistics.
        /// </summary>
        private static List<Statistic> statistics;

        /// <summary>
        ///     The property for random numbers.
        /// </summary>
        private Random random;

        /// <summary>
        ///     The constructor initialize MainView, PizzaInitializer, statistics list and Random classes
        /// </summary>
        public PizzaResolver()
        {
            mainView = new MainView();
            pizzaInitializator = new PizzaInitializator();
            statistics = new List<Statistic>();
            random = new Random(); 
        }

        /// <remarks>
        ///     The method manage choose of player. 
        ///     If <c>option</c> variable is not 1, 2, 3 or 4 throws FormatException.
        /// </remarks>
        /// <returns></returns>
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

        /// <summary>
        ///     The method allows switch from one mode to another.
        /// </summary>
        /// <param name="option"></param>
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

        /// <remarks>
        ///     The method sorts list and render their elements to console.
        ///     If list has zero length it's displays communicate that data is not available.
        /// </remarks>
        /// <param name="statistics"></param>
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
                mainView.ShowNoAvailableStatistics();
            }
            
        }
        
        /// <summary>
        ///     The method manage 1 vs computer game mode.
        /// </summary>
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

            CheckThatPlayerExistInStatistics(myStatistics);
            CheckThatPlayerExistInStatistics(computerStatistics);
        }

        /// <summary>
        ///     The method manage 1 vs 1 game mode.
        /// </summary>
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

            CheckThatPlayerExistInStatistics(firstPlayerStatistics);
            CheckThatPlayerExistInStatistics(secondPlayerStatistics);
        }

        /// <summary>
        ///     The method take decision who is winner.
        /// </summary>
        /// <param name="name">
        ///     <summary>
        ///         The name of first player.
        ///     </summary>
        /// </param>
        /// <param name="secondNamePlayer">
        ///     <summary>
        ///         The name of second player.
        ///     </summary>
        /// </param>
        public void ChooseWinner(string name, string secondNamePlayer)
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

        /// <summary>
        ///     The method computes and assigns scores to specified player.
        /// </summary>
        /// <param name="myPizza">
        ///     <summary>
        ///         The parameter <c>myPizza</c> is randomly returned object of Pizza class which is assigned to first player.
        ///     </summary>
        /// </param>
        /// <param name="computerPizza">
        ///     <summary>
        ///         The parameter <c>computerPizza</c> is randomly returned object of Pizza class which is assigned to second player.
        ///     </summary>
        /// </param>
        /// <param name="myStatistics">
        ///     <summary>
        ///         The parameter is statistic object which is assigned to first player.
        ///     </summary>
        /// </param>
        /// <param name="computerStatistics">
        ///     <summary>
        ///         The parameter is statistic object which is assigned to second player.
        ///     </summary>
        /// </param>
        public void ComputeAndAssignScore(Pizza myPizza, Pizza computerPizza,
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

        /// <summary>
        ///     The method randomly returns two Pizza object, render them and manage scores for players.
        /// </summary>
        /// <param name="name">
        ///     <summary>
        ///         The parameter is name for first player.
        ///     </summary>    
        /// </param>
        /// <param name="myStatistics">
        ///     <summary>
        ///         The parameter is statistic object which is assigned to first player.
        ///     </summary>
        /// </param>
        /// <param name="computerStatistics">
        ///     <summary>
        ///         The parameter is statistic object which is assigned to second player.
        ///     </summary>
        /// </param>
        /// <param name="secondNamePlayer">
        ///     <summary>
        ///         The parameter is name for second player.
        ///     </summary>
        /// </param>
        public void ManageGameQueue(string name, Statistic myStatistics, Statistic computerStatistics, string secondNamePlayer)
        {
            int randomIndex1 = random.Next(0, pizzaInitializator.pizzas.Count);
            int randomIndex2 = random.Next(0, pizzaInitializator.pizzas.Count);

            Pizza myPizza = pizzaInitializator.pizzas[randomIndex1];
            Pizza computerPizza = pizzaInitializator.pizzas[randomIndex2];

            Console.WriteLine(myPizza.ToString(name));
            Console.WriteLine(computerPizza.ToString(secondNamePlayer));

            isPlayerWinner = false;
            ComputeAndAssignScore(myPizza, computerPizza, myStatistics, computerStatistics);
            ChooseWinner(name, secondNamePlayer);

            mainView.ShowReadKeyForContinueGame();
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        ///     The method checks that player already exist in statistics list.
        /// </summary>
        /// <param name="statistic">
        ///     <summary>
        ///         The parameter is field list for storing statistics data.
        ///     </summary>
        /// </param>
        public void CheckThatPlayerExistInStatistics(Statistic statistic)
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

        /// <summary>
        ///     The method resets values for score variables.
        /// </summary>
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
