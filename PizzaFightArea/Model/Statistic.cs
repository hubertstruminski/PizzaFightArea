using System;

namespace PizzaFightArea.Model
{
    /// <summary>
    /// Class <c>Statistic</c> 
    /// <remarks>
    ///     The class models object for statistic data
    /// </remarks>
    /// </summary>
    public class Statistic
    {
        /// <summary>
        /// Property <c>Nick</c>
        /// <remarks>
        ///     The property describes name of player.
        /// </remarks>
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// Property <c>Score</c>
        /// <remarks>
        ///     The property describes number of points for specified player.
        /// </remarks>
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// arg-constructor for <c>Statistic</c> model class
        /// <remarks>
        ///     The arg-constructor initializes <c>nick</c> and <c>score</c> fields.
        /// </remarks>
        /// </summary>
        /// <param name="nick">
        ///     <remarks>
        ///         The parameter is nick of player to who belongs this <c>Statistic</c> object.
        ///     </remarks>
        /// </param>
        /// <param name="score"></param>
        public Statistic(string nick, int score)
        {
            this.Nick = nick;
            this.Score = score;
        }

        /// <summary>
        /// Method <c>ToString</c>
        /// <remarks>
        ///     Overrided method <c>ToString</c> for generatinf statistic view
        /// </remarks>
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
