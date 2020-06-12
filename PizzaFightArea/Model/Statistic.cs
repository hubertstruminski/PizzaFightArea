using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace PizzaFightArea.Model
{
    public class Statistic
    {
        private string nick { get; set; }
        private int score { get; set; }

        public Statistic(string nick, int score)
        {
            this.nick = nick;
            this.score = score;
        }
    }
}
