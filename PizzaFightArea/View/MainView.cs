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

        public void ShowInputNikCommandForSecondPlayer()
        {
            Console.Write("\nInput name for second player: ");
        }

        public void ShowWinner(string name)
        {
            Console.WriteLine("The winner is: " + name);
        }

        public void ShowDeadHeat()
        {
            Console.WriteLine("Dead-Heat.");
        }

        public void ShowReadKeyForContinueGame()
        {
            Console.Write("Click any key to continue game...");
        }

        public void ShowScores(string name, int playerWins, int playerLosts, int playerDeadHeats,
            string secondPlayerName, int player2Wins, int player2Losts)
        {
            Console.WriteLine("Scores for " + name);
            Console.WriteLine("Wins: " + playerWins);
            Console.WriteLine("Losts: " + playerLosts + "\n");

            Console.WriteLine("Scores for " + secondPlayerName);
            Console.WriteLine("Wins: " + player2Wins);
            Console.WriteLine("Losts: " + player2Losts);

            Console.WriteLine("Dead Heats: " + playerDeadHeats);
        }
    }
}
