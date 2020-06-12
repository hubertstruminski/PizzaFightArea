using System;

namespace PizzaFightArea.View
{
    public class MainView
    {
        /// <summary>
        /// Method <c>ShowMainMenu</c>
        /// <remarks>
        ///     The method render view of main menu.
        ///     The menu has red background and white font color.
        /// </remarks>
        /// </summary>
        public void ShowMainMenu()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nPizza Fight Area");
            Console.WriteLine("----------------");
            Console.WriteLine("1. New game - 1 vs Computer");
            Console.WriteLine("2. New game - 1 vs 1");
            Console.WriteLine("3. Statistics");
            Console.WriteLine("4. Exit");
            Console.WriteLine("----------------");
            Console.Write("Option: ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Method <c>ShowOptionChooseError</c>
        /// <remarks>
        ///     The method renders communicate that choosen option in main menu is not correct.
        /// </remarks>
        /// </summary>
        public void ShowOptionChooseError()
        {
            Console.WriteLine("It's not a number.");
        }

        /// <summary>
        /// Method <c>ShowInputNickCommand</c>
        /// <remarks>
        ///     The method renders communicate for input nick for first player.
        /// </remarks>
        /// </summary>
        public void ShowInputNickCommand()
        {
            Console.Write("\nInput your Name: ");
        }

        /// <summary>
        /// Method <c>ShowInputNickCommandForSecondPlayer</c>
        /// <remarks>
        ///     The method shows communicate to second player for input name.
        /// </remarks>
        /// </summary>
        public void ShowInputNikCommandForSecondPlayer()
        {
            Console.Write("\nInput name for second player: ");
        }

        /// <summary>
        /// Method <c>ShowWinner</c>
        /// <remarks>
        ///     The method shows communicate who is winner.
        /// </remarks>
        /// </summary>
        /// <param name="name"></param>
        public void ShowWinner(string name)
        {
            Console.WriteLine("The winner is: " + name);
        }

        /// <summary>
        /// Method <c>ShowDeadHeat</c>
        /// <remarks>
        ///     The method shows communicate about numbers of dead heat.
        /// </remarks>
        /// </summary>
        public void ShowDeadHeat()
        {
            Console.WriteLine("Dead-Heat.");
        }

        /// <summary>
        /// Method <c>ShowReadKeyForContinueGame</c>
        /// <remarks>
        ///     The method shows communicate to player for input any key to continue game.
        /// </remarks>
        /// </summary>
        public void ShowReadKeyForContinueGame()
        {
            Console.Write("Click any key to continue game...");
        }

        /// <summary>
        /// Method <c>ShowScores</c>
        /// <remarks>
        ///     The method shows score for players.
        ///     It's sets red background for headers with nick and white font color
        /// </remarks>
        /// </summary>
        /// <param name="name">
        ///     <remarks>
        ///         The parameters is nick of first player.
        ///     </remarks>
        /// </param>
        /// <param name="playerWins">
        ///     <remarks>
        ///         The parameter is number of wins for first player
        ///     </remarks>
        /// </param>
        /// <param name="playerLosts">
        ///     <remarks>
        ///         The parameter is number of losts for first player
        ///     </remarks>
        /// </param>
        /// <param name="playerDeadHeats">
        ///     <remarks>
        ///         The parameter is number of dead heats for players
        ///     </remarks>
        /// </param>
        /// <param name="secondPlayerName">
        ///     <remarks>
        ///         The parameters is nick of second player.
        ///     </remarks>
        /// </param>
        /// <param name="player2Wins">
        ///     <remarks>
        ///         The parameter is number of wins for second player
        ///     </remarks>
        /// </param>
        /// <param name="player2Losts">
        ///     <remarks>
        ///         The parameter is number of losts for second player
        ///     </remarks>
        /// </param>
        public void ShowScores(string name, int playerWins, int playerLosts, int playerDeadHeats,
            string secondPlayerName, int player2Wins, int player2Losts)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Scores for " + name);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Wins: " + playerWins);
            Console.WriteLine("Losts: " + playerLosts + "\n");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Scores for " + secondPlayerName);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Wins: " + player2Wins);
            Console.WriteLine("Losts: " + player2Losts);

            Console.WriteLine("Dead Heats: " + playerDeadHeats);
        }

        /// <summary>
        /// Method <c>ShowNoAvailableStatistics</c>
        /// <remarks>
        ///     The method shows communicate that statistics are not available.
        /// </remarks>
        /// </summary>
        public void ShowNoAvailableStatistics()
        {
            Console.WriteLine("No available statistics.");
        }
    }
}
