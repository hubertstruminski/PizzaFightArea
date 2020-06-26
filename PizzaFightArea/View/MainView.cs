using System;

namespace PizzaFightArea.View
{
    public class MainView
    {
        /// <remarks>
        ///     The method render view of main menu.
        ///     The menu has red background and white font color.
        /// </remarks>
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
        ///     The method renders communicate that choosen option in main menu is not correct.
        /// </summary>
        public void ShowOptionChooseError()
        {
            Console.WriteLine("It's not a number.");
        }

        /// <summary>
        ///     The method renders communicate for input nick for first player.
        /// </summary>
        public void ShowInputNickCommand()
        {
            Console.Write("\nInput your Name: ");
        }

        /// <summary>
        ///     The method shows communicate to second player for input name.
        /// </summary>
        public void ShowInputNikCommandForSecondPlayer()
        {
            Console.Write("\nInput name for second player: ");
        }

        /// <summary>
        ///     The method shows communicate who is winner.
        /// </summary>
        /// <param name="name"></param>
        public void ShowWinner(string name)
        {
            Console.WriteLine("The winner is: " + name);
        }

        /// <summary>
        ///     The method shows communicate about numbers of dead heat.
        /// </summary>
        public void ShowDeadHeat()
        {
            Console.WriteLine("Dead-Heat.");
        }

        /// <summary>
        ///     The method shows communicate to player for input any key to continue game.
        /// </summary>
        public void ShowReadKeyForContinueGame()
        {
            Console.Write("Click any key to continue game...");
        }

        /// <remarks>
        ///     The method shows score for players.
        ///     It's sets red background for headers with nick and white font color
        /// </remarks>
        /// <param name="name">
        ///     <summary>
        ///         The parameters is nick of first player.
        ///     </summary>
        /// </param>
        /// <param name="playerWins">
        ///     <summary>
        ///         The parameter is number of wins for first player
        ///     </summary>
        /// </param>
        /// <param name="playerLosts">
        ///     <summary>
        ///         The parameter is number of losts for first player
        ///     </summary>
        /// </param>
        /// <param name="playerDeadHeats">
        ///     <summary>
        ///         The parameter is number of dead heats for players
        ///     </summary>
        /// </param>
        /// <param name="secondPlayerName">
        ///     <summary>
        ///         The parameters is nick of second player.
        ///     </summary>
        /// </param>
        /// <param name="player2Wins">
        ///     <summary>
        ///         The parameter is number of wins for second player
        ///     </summary>
        /// </param>
        /// <param name="player2Losts">
        ///     <summary>
        ///         The parameter is number of losts for second player
        ///     </summary>
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
        ///     The method shows communicate that statistics are not available.
        /// </summary>
        public void ShowNoAvailableStatistics()
        {
            Console.WriteLine("No available statistics.");
        }
    }
}
