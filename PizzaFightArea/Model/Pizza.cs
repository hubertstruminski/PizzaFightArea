using PizzaFightArea.Enum;
using System;
using System.Text;

namespace PizzaFightArea.Model
{
    /// <summary>
    /// The class which models Pizza object
    /// </summary>
    public class Pizza
    {
        /// <summary>
        /// The property which describe name of pizza
        /// </summary>
        private PizzaName Name { get; set; }

        /// <summary>
        /// The property which describes level of hunger.
        /// </summary>
        private int Hunger { get; set; }

        /// <summary>
        /// The property which describes level of sharpness.
        /// </summary>
        private int Sharpness { get; set; }

        /// <summary>
        /// The property which describes level of flavor.
        /// </summary>
        private int Flavor { get; set; }

        /// <summary>
        /// The property which describes shape of pizza.
        /// </summary>
        private PizzaShape Shape { get; set; }

        /// <summary>
        /// The property which describes level of smell.
        /// </summary>
        private int Smell { get; set; }

        /// <summary>
        /// The property which describes number of points.
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// <remarks>
        ///     The arg-constructor initializes fields: name, hunger, sharpness, flavor, shape, smell.
        ///     The constructor computes number of points for specified Pizza.
        /// </remarks>
        /// </summary>
        /// <param Name="name"></param>
        /// <param Name="Hunger"></param>
        /// <param Name="Sharpness"></param>
        /// <param Name="Flavor"></param>
        /// <param Name="Shape"></param>
        /// <param Name="Smell"></param>
        public Pizza(PizzaName name, int hunger, int sharpness, int flavor, PizzaShape shape, int smell)
        {
            this.Name = name;
            this.Hunger = hunger;
            this.Sharpness = sharpness;
            this.Flavor = flavor;
            this.Shape = shape;
            this.Smell = smell;
            this.Score = Math.Round(hunger * 0.87 + sharpness * 0.92 + flavor * 0.23 + ComputeShapeScore(shape) + smell * 0.43, 2);
        }

        /// <remarks>
        /// Method <c>ToString</c> generates view of pizza table.
        /// Method takes parameter <c>yournick</c> type of string which is current Name of player
        /// </remarks>
        /// <param Name="yourNick"></param>
        /// <returns>
        ///     The returned value is string representation of Pizza view.
        /// </returns>
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

            ProcessFieldsToTable(entireLength, "Pizza", Name.ToString(), builder);

            builder.Append("|").Append(new string(' ', entireLength - 2)).Append("|").Append("\n");

            ProcessFieldsToTable(entireLength, "Hunger", Hunger.ToString(), builder);
            ProcessFieldsToTable(entireLength, "Sharpness", Sharpness.ToString(), builder);
            ProcessFieldsToTable(entireLength, "Flavor", Flavor.ToString(), builder);
            ProcessFieldsToTable(entireLength, "Smell", Smell.ToString(), builder);

            builder.Append("|").Append(new string(' ', entireLength - 2)).Append("|").Append("\n");

            ProcessFieldsToTable(entireLength, "Shape", Shape.ToString(), builder);

            builder.Append("|").Append(new string(' ', entireLength - 2)).Append("|").Append("\n");

            ProcessFieldsToTable(entireLength, "Score", Score.ToString(), builder);

            builder.Append("|").Append(new string(' ', entireLength - 2)).Append("|").Append("\n");
            builder.Append(new string('-', entireLength)).Append("\n");

            return builder.ToString();
        }

        /// <summary>
        /// The method generates single line to view of pizza table for single property of pizza model
        /// </summary>
        /// <param Name="entireLength"></param>
        /// <param Name="fieldName"></param>
        /// <param Name="field"></param>
        /// <param Name="builder"></param>
        public void ProcessFieldsToTable(int entireLength, string fieldName, string field, StringBuilder builder)
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

        /// <summary>
        /// The method returns computed score for specified enum value of shape
        /// </summary>
        /// <param name="pizzaShape"></param>
        /// <returns>Returns value of score</returns>
        public double ComputeShapeScore(PizzaShape pizzaShape)
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
