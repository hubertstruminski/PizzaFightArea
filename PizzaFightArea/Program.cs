using PizzaFightArea.Model;
using PizzaFightArea.Service;
using PizzaFightArea.View;
using System;
using System.Collections.Generic;

namespace PizzaFightArea
{
    class Program
    {
        static void manageMenu()
        {
            MainView mainView = new MainView();
            mainView.showMainMenu();
        }
        static void Main(string[] args)
        {
            manageMenu();
            PizzaInitializator initializator = new PizzaInitializator();
            List<Pizza> pizzas = initializator.pizzas;

            //Random random = new Random();
            //int randomIndex = random.Next(0, pizzas.Count);
            //Pizza pizza = pizzas[randomIndex];
            //Console.WriteLine(pizza.ToString("Hubert"));
            //Console.WriteLine(pizzas[15].ToString("Computer"));

            int count = 1;
            foreach(Pizza pizza in pizzas)
            {
                Console.WriteLine(pizza.ToString("Hubert " + count));
                count++;
            }

        }
    }
}
