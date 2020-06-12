using PizzaFightArea.Model;
using PizzaFightArea.Service;
using System;
using System.Collections.Generic;

namespace PizzaFightArea
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaInitializator initializator = new PizzaInitializator();
            List<Pizza> pizzas = initializator.pizzas;

            Random random = new Random();
            int randomIndex = random.Next(0, pizzas.Count);
            Pizza pizza = pizzas[randomIndex];
            Console.WriteLine(pizza.ToString("Hubert"));
            Console.WriteLine(pizzas[15].ToString("Computer"));
        }
    }
}
