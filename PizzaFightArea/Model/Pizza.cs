using PizzaFightArea.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFightArea.Model
{
    public class Pizza
    {
        private PizzaName name { get; set; }
        private int hunger { get; set; }
        private int sharpness { get; set; }
        private int flavor { get; set; }
        private PizzaShape shape { get; set; }
        private int smell { get; set; }

        public Pizza(PizzaName name, int hunger, int sharpness, int flavor, PizzaShape shape, int smell)
        {
            this.name = name;
            this.hunger = hunger;
            this.sharpness = sharpness;
            this.flavor = flavor;
            this.shape = shape;
            this.smell = smell;
        }
    }
}
