using PizzaFightArea.Service;

namespace PizzaFightArea
{
    /// <summary>
    ///     The class is responsible for start the application.
    /// </summary>
    class Program
    {
        /// <summary>
        ///     The method which manage all the application flow.
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
        ///     The method starts the application.
        /// </summary>
        /// <param name="args">
        ///     <summary>
        ///         The parameter is inputs from command line in console.
        ///     </summary>
        /// </param>
        static void Main(string[] args)
        {
            ManageMenu();
        }
    }
}
