using PizzaFightArea.Enum;
using PizzaFightArea.Model;
using System;
using System.Collections.Generic;

namespace PizzaFightArea.Service
{
    /// <summary>
    ///     <c>PizzaInitializator</c> class which stores <c>pizzas</c> field
    /// </summary>
    public class PizzaInitializator
    {
        /// <summary>
        ///     The property stores data about pizzas.
        /// </summary>
        public List<Pizza> pizzas;

        /// <summary>
        ///     The constructor which initialize <c>pizzas</c> field with Pizza data
        /// </summary>
        public PizzaInitializator()
        {
            pizzas = new List<Pizza>() 
            { 
                new Pizza(PizzaName.CAMPIONE, 67, 32, 37, PizzaShape.CIRCLE, 84),
                new Pizza(PizzaName.CAPRICIOSA, 31, 17, 27, PizzaShape.RECTANGLE, 19),
                new Pizza(PizzaName.DECORO, 87, 41, 65, PizzaShape.TRIANGLE, 32),
                new Pizza(PizzaName.INVERNO, 93, 11, 45, PizzaShape.SQUARE, 67),
                new Pizza(PizzaName.MAFIOSO, 87, 78, 7, PizzaShape.CIRCLE, 87),
                new Pizza(PizzaName.MARGHERITA, 11, 21, 89, PizzaShape.CIRCLE, 89),
                new Pizza(PizzaName.NAPOLETANA, 32, 54, 99, PizzaShape.CIRCLE, 21),
                new Pizza(PizzaName.PARMA, 6, 11, 89, PizzaShape.CIRCLE, 7),
                new Pizza(PizzaName.PEPPERONI, 2, 34, 76, PizzaShape.RECTANGLE, 15),
                new Pizza(PizzaName.PIACERE, 58, 98, 12, PizzaShape.SQUARE, 31),
                new Pizza(PizzaName.POLSKA, 31, 78, 89, PizzaShape.TRIANGLE, 47),
                new Pizza(PizzaName.ROMA, 15, 32, 37, PizzaShape.RECTANGLE, 58),
                new Pizza(PizzaName.SEMPLICITA, 68, 56, 39, PizzaShape.SQUARE, 63),
                new Pizza(PizzaName.SPARARE, 74, 18, 26, PizzaShape.TRIANGLE, 71),
                new Pizza(PizzaName.WIEJSKA, 71, 56, 79, PizzaShape.CIRCLE, 39),
                new Pizza(PizzaName.CAMPIONE, 98, 13, 90, PizzaShape.RECTANGLE, 31),
                new Pizza(PizzaName.CAPRICIOSA, 100, 76, 98, PizzaShape.SQUARE, 14),
                new Pizza(PizzaName.DECORO, 95, 21, 65, PizzaShape.CIRCLE, 78),
                new Pizza(PizzaName.INVERNO, 64, 57, 78, PizzaShape.TRIANGLE, 98),
                new Pizza(PizzaName.MAFIOSO, 98, 72, 96, PizzaShape.SQUARE, 100),
                new Pizza(PizzaName.MARGHERITA, 91, 87, 45, PizzaShape.RECTANGLE, 46),
                new Pizza(PizzaName.NAPOLETANA, 69, 74, 68, PizzaShape.TRIANGLE, 32),
                new Pizza(PizzaName.PARMA, 89, 78, 67, PizzaShape.SQUARE, 12),
                new Pizza(PizzaName.PEPPERONI, 89, 84, 90, PizzaShape.TRIANGLE, 5),
                new Pizza(PizzaName.PIACERE, 98, 56, 87, PizzaShape.CIRCLE, 3),
                new Pizza(PizzaName.POLSKA, 68, 54, 97, PizzaShape.CIRCLE, 100),
                new Pizza(PizzaName.ROMA, 89, 97, 53, PizzaShape.CIRCLE, 74),
                new Pizza(PizzaName.SEMPLICITA, 63, 85, 89, PizzaShape.CIRCLE, 71),
                new Pizza(PizzaName.SPARARE, 61, 58, 77, PizzaShape.CIRCLE, 86),
                new Pizza(PizzaName.WIEJSKA, 69, 64, 97, PizzaShape.TRIANGLE, 83),
                new Pizza(PizzaName.CAMPIONE, 65, 61, 87, PizzaShape.RECTANGLE, 62),
                new Pizza(PizzaName.CAPRICIOSA, 63, 53, 47, PizzaShape.CIRCLE, 59)
            };
        }
    }
}
