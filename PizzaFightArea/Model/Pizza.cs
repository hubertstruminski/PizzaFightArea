using PizzaFightArea.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFightArea.Model
{
    /// <summary>
    /// <c>Pizza</c> class which models Pizza object
    /// </summary>
    public class Pizza
    {
        private PizzaName name { get; set; }
        private int hunger { get; set; }
        private int sharpness { get; set; }
        private int flavor { get; set; }
        private PizzaShape shape { get; set; }
        private int smell { get; set; }
        private double score { get; set; }

        /// <summary>
        /// Argument constructor for <c>Pizza</c> class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hunger"></param>
        /// <param name="sharpness"></param>
        /// <param name="flavor"></param>
        /// <param name="shape"></param>
        /// <param name="smell"></param>
        public Pizza(PizzaName name, int hunger, int sharpness, int flavor, PizzaShape shape, int smell)
        {
            this.name = name;
            this.hunger = hunger;
            this.sharpness = sharpness;
            this.flavor = flavor;
            this.shape = shape;
            this.smell = smell;
            this.score = Math.Round(hunger * 0.87 + sharpness * 0.92 + flavor * 0.23 + computeShapeValue(shape) + smell * 0.43, 2);
        }

        /// <summary>
        /// Method <c>ToString</c> generates view of pizza table.
        /// Method takes parameter <c>yournick</c> type of string which is current name of player
        /// </summary>
        /// <param name="yourNick"></param>
        /// <returns></returns>
        public string ToString(string yourNick)
        {
            StringBuilder builder = new StringBuilder();

            int entireLength = 30;
            builder.Append(new string('-', entireLength)).Append("\n");

            int spaceLength = entireLength - "|".Length - "|".Length - yourNick.Length;

            int leftSpaceLength;
            int rightSpaceLength;
            if(spaceLength % 2 == 0)
            {
                int result = spaceLength / 2;
                leftSpaceLength = result;
                rightSpaceLength = result;
            } else
            {
                int result = (spaceLength - 1) / 2;
                leftSpaceLength = result;
                rightSpaceLength = result + 1;
            }

            builder.Append("|")
                .Append(new string(' ', leftSpaceLength))
                .Append(yourNick)
                .Append(new string(' ', rightSpaceLength))
                .Append("|").Append("\n");

            builder.Append(new string('-', entireLength)).Append("\n");

            builder.Append("|").Append(new string(' ', entireLength - 2)).Append("|").Append("\n");

            processFieldsToTable(entireLength, "Pizza", name.ToString(), builder);

            builder.Append("|").Append(new string(' ', entireLength - 2)).Append("|").Append("\n");

            processFieldsToTable(entireLength, "Hunger", hunger.ToString(), builder);
            processFieldsToTable(entireLength, "Sharpness", sharpness.ToString(), builder);
            processFieldsToTable(entireLength, "Flavor", flavor.ToString(), builder);
            processFieldsToTable(entireLength, "Smell", smell.ToString(), builder);

            builder.Append("|").Append(new string(' ', entireLength - 2)).Append("|").Append("\n");

            processFieldsToTable(entireLength, "Shape", shape.ToString(), builder);

            builder.Append("|").Append(new string(' ', entireLength - 2)).Append("|").Append("\n");

            processFieldsToTable(entireLength, "Score", score.ToString(), builder);

            builder.Append("|").Append(new string(' ', entireLength - 2)).Append("|").Append("\n");
            builder.Append(new string('-', entireLength)).Append("\n");

            return builder.ToString();
        }

        /// <summary>
        /// Method <c>processFieldsToTable</c> generate single line to 
        /// view of pizza table for single property of pizza model
        /// </summary>
        /// <param name="entireLength"></param>
        /// <param name="fieldName"></param>
        /// <param name="field"></param>
        /// <param name="builder"></param>
        public void processFieldsToTable(int entireLength, string fieldName, string field, StringBuilder builder)
        {
            string fieldString = fieldName + ": " + field;
            int fieldStringLength = fieldString.Length;

            int spaceLength = entireLength - "|".Length - "|".Length - fieldStringLength;

            int leftSpaceLength;
            int rightSpaceLength;
            if(spaceLength % 2 == 0)
            {
                int result = spaceLength / 2;
                leftSpaceLength = result;
                rightSpaceLength = result;

            } else
            {
                int result = (spaceLength - 1) / 2;
                leftSpaceLength = result;
                rightSpaceLength = result + 1;
            }

            builder.Append("|")
                .Append(new string(' ', leftSpaceLength))
                .Append(fieldString)
                .Append(new string(' ', rightSpaceLength))
                .Append("|")
                .Append("\n");
        }

        public double computeShapeValue(PizzaShape pizzaShape)
        {
            int result;
            if(pizzaShape == PizzaShape.CIRCLE)
            {
                result = 80;
            } else if(pizzaShape == PizzaShape.RECTANGLE)
            {
                result = 65;
            } else if(pizzaShape == PizzaShape.SQUARE)
            {
                result = 72;
            } else if(pizzaShape == PizzaShape.TRIANGLE)
            {
                result = 51;
            } else
            {
                result = 0;
            }
            return result;
        }
    }
}
