using PizzaFightArea.Service;

namespace PizzaFightArea
{
    class Program
    {
        static void ManageMenu()
        {
            PizzaResolver resolver = new PizzaResolver();
            while(true)
            {
                int option = resolver.ChooseOptionInMainMenu();
                resolver.SwitchToDestinationOption(option);
            }
        }

        static void Main(string[] args)
        {
            ManageMenu();
        }
    }
}
