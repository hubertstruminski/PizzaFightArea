using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace PizzaFightArea.Model
{
    public class Statistic
    {
        private string Nick { get; set; }
        private double Score { get; set; }

        public Statistic(string nick, int score)
        {
            this.Nick = nick;
            this.Score = score;
        }
    }
}
