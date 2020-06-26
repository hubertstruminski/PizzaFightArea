using System;

namespace PizzaFightArea.Model
{
    /// <summary>
    ///     The class models object for statistic data
    /// </summary>
    public class Statistic
    {
        /// <summary>
        ///     The property describes name of player.
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        ///     The property describes number of points for specified player.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        ///     The arg-constructor initializes <c>nick</c> and <c>score</c> fields.
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="score"></param>
        public Statistic(string nick, int score)
        {
            this.Nick = nick;
            this.Score = score;
        }

        /// <summary>
        ///     Overrided method <c>ToString</c> for generatinf statistic view
        /// </summary>
        /// <returns>
        ///     The value is returned string representation of Statistic object.
        /// </returns>
        public override string ToString()
        {
            return Nick + ": " + Math.Round(Score, 2) + " points"; 
        }
    }
}
