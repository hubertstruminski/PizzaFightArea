using System;

namespace PizzaFightArea.Model
{
    public class Statistic
    {
        public string Nick { get; set; }
        public double Score { get; set; }

        public Statistic(string nick, int score)
        {
            this.Nick = nick;
            this.Score = score;
        }

        public override string ToString()
        {
            return Nick + ": " + Math.Round(Score, 2) + " points"; 
        }
    }
}
