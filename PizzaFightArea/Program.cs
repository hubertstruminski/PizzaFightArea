using PizzaFightArea.Service;

namespace PizzaFightArea
{
    /// <summary>
    /// The class <c>Program</c>
    /// <remarks>
    ///     The class is responsible for start the application.
    /// </remarks>
    /// </summary>
    class Program
    {
        /// <summary>
        /// Method <c>ManageMenu</c>
        /// <remarks>
        ///     The method which manage all the application flow.
        /// </remarks>
        /// </summary>
        static void ManageMenu()
        {
            PizzaResolver resolver = new PizzaResolver();
            while(true)
            {
                int option = resolver.ChooseOptionInMainMenu();
                resolver.SwitchToDestinationOption(option);
            }
        }

        /// <summary>
        /// Method <c>Main</c>
        /// <remarks>
        ///     The method starts the application.
        /// </remarks>
        /// </summary>
        /// <param name="args">
        ///     <remarks>
        ///         The parameter is inputs from command line in console.
        ///     </remarks>
        /// </param>
        static void Main(string[] args)
        {
            ManageMenu();
        }
    }
}
