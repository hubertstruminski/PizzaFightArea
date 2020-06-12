using PizzaFightArea.Model;
using PizzaFightArea.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaFightArea.Service
{
    /// <summary>
    /// <c>PizzaResolver</c> class
    /// <remarks>
    ///     The class which is responsible for management functionalities
    /// </remarks>
    /// </summary>
    public class PizzaResolver
    {
        /// <summary>
        /// Property <c>MainView</c>
        /// </summary>
        private MainView mainView;

        /// <summary>
        /// Property <c>PizzaInnitializator</c>
        /// </summary>
        private PizzaInitializator pizzaInitializator;

        /// <summary>
        /// Property <c>playerWins</c>
        /// <remarks>
        ///     The property describes how often first player has been won.
        /// </remarks>
        /// </summary>
        private int playerWins = 0;

        /// <summary>
        /// Property <c>playerLosts</c>
        /// <remarks>
        ///     The property describes number of losts for first player.
        /// </remarks>
        /// </summary>
        private int playerLosts = 0;

        /// <summary>
        /// Property <c>playerDeadHeats</c>
        /// <remarks>
        ///     The property describes number of dead heats for first player.
        /// </remarks>
        /// </summary>
        private int playerDeadHeats = 0;

        /// <summary>
        /// Property <c>secondPlayerWins</c>
        /// <remarks>
        ///     The property describes number of wins for second player
        /// </remarks>
        /// </summary>
        private int secondPlayerWins = 0;

        /// <summary>
        /// Property <c>secondPlayerLosts</c>
        /// <remarks>
        ///     The property describes number of losts for second player.
        /// </remarks>
        /// </summary>
        private int secondPlayerLosts = 0;

        /// <summary>
        /// Property <c>isPlayerWinner</c>
        /// <remarks>
        ///     The property is flag which indicates who is winner.
        /// </remarks>
        /// </summary>
        private bool isPlayerWinner = false;

        /// <summary>
        /// Property <c>statistics</c>
        /// <remarks>
        ///     The property which stores data about statistics.
        /// </remarks>
        /// </summary>
        private static List<Statistic> statistics;

        /// <summary>
        /// Property <c>random</c>
        /// <remarks>
        ///     The property for random numbers.
        /// </remarks>
        /// </summary>
        private Random random;

        /// <summary>
        /// No-arg-constructor <c>PizzaResolver</c> class
        /// <remarks>
        ///     The constructor initialize MainView, PizzaInitializer, statistics list and Random classes
        /// </remarks>
        /// </summary>
        public PizzaResolver()
        {
            mainView = new MainView();
            pizzaInitializator = new PizzaInitializator();
            statistics = new List<Statistic>();
            random = new Random(); 
        }

        /// <summary>
        /// Method <c>ChooseOptionInMainMenu</c>
        /// <remarks>
        ///     The method manage choose of player. 
        ///     If <c>option</c> parameter is not 1, 2, 3 or 4 throws FormatException.
        /// </remarks>
        /// </summary>
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
        /// Method <c>SwitchToDestinationOption</c>
        /// <remarks>
        ///     The method allows switch from one mode to another.
        /// </remarks>
        /// </summary>
        /// <param name="option">
        ///     <remarks>
        ///         The value returned by <c>ChooseOptionInMainMenu</c> method which is choose of player.
        ///     </remarks>
        /// </param>
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

        /// <summary>
        /// Method <c>ManageStatistics</c>
        /// <remarks>
        ///     The method sorts list and render their elements to console.
        ///     If list has zero length it's displays communicate that data is not available.
        /// </remarks>
        /// </summary>
        /// <param name="statistics">
        ///     <remarks>
        ///         The field which stores data about statistic players.
        ///     </remarks>
        /// </param>
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
        
        /// <summary>
        /// Method <c>Manage1VsComputer</c>
        /// <remarks>
        ///     The method manage 1 vs computer game mode.
        /// </remarks>
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
        /// Method <c>Manage1Vs1</c>
        /// <remarks>
        ///     The method manage 1 vs 1 game mode.
        /// </remarks>
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
        /// Method <c>ChooseWinner</c>
        /// <remarks>
        ///     The method take decision who is winner.
        /// </remarks>
        /// </summary>
        /// <param name="name">
        ///     <remarks>
        ///         The name of first player.
        ///     </remarks>
        /// </param>
        /// <param name="secondNamePlayer">
        ///     <remarks>
        ///         The name of second player.
        ///     </remarks>
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
        /// Method <c>ComputeAndAssignScore</c>
        /// <remarks>
        ///     The method computes and assigns scores to specified player.
        /// </remarks>
        /// </summary>
        /// <param name="myPizza">
        ///     <remarks>
        ///         The parameter <c>myPizza</c> is randomly returned object of Pizza class which is assigned to first player.
        ///     </remarks>
        /// </param>
        /// <param name="computerPizza">
        ///     <remarks>
        ///         The parameter <c>computerPizza</c> is randomly returned object of Pizza class which is assigned to second player.
        ///     </remarks>
        /// </param>
        /// <param name="myStatistics">
        ///     <remarks>
        ///         The parameter is statistic object which is assigned to first player.
        ///     </remarks>
        /// </param>
        /// <param name="computerStatistics">
        ///     <remarks>
        ///         The parameter is statistic object which is assigned to second player.
        ///     </remarks>
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
        /// Method <c>ManageGameQueue</c>
        /// <remarks>
        ///     The method randomly returns two Pizza object, render them and manage scores for players.
        /// </remarks>
        /// </summary>
        /// <param name="name">
        ///     <remarks>
        ///         The parameter is name for first player.
        ///     </remarks>    
        /// </param>
        /// <param name="myStatistics">
        ///     <remarks>
        ///         The parameter is statistic object which is assigned to first player.
        ///     </remarks>
        /// </param>
        /// <param name="computerStatistics">
        ///     <remarks>
        ///         The parameter is statistic object which is assigned to second player.
        ///     </remarks>
        /// </param>
        /// <param name="secondNamePlayer">
        ///     <remarks>
        ///         The parameter is name for second player.
        ///     </remarks>
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
        /// Method <c>CheckThatPlayerExistInStatistics</c>
        /// <remarks>
        ///     The method checks that player already exist in statistics list.
        /// </remarks>
        /// </summary>
        /// <param name="statistic">
        ///     <remarks>
        ///         The parameter is field list for storing statistics data.
        ///     </remarks>
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
        /// Method <c>RestartScores</c>
        /// <remarks>
        ///     The method resets values for score variables.
        /// </remarks>
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
