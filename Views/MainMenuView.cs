using ProjetoLandisGyr.Helpers;

namespace ProjetoLandisGyr.Views
{
    internal class MainMenuView
    {
        public static void Menu()
        {
            Console.Clear();

            MenuOption(1, "Insert a New Endpoint");
            MenuOption(2, "Edit an Existing Endpoint");
            MenuOption(3, "Delete an Existing Endpoint");
            MenuOption(4, "List All Endpoints");
            MenuOption(5, "Find a Endpoint By \"Serial Number\"");
            MenuOption(6, "Exit");
        }

        public static void MenuOption(int index, string name)
        {
            Console.WriteLine($"{index}) {name}");
        }

        public static bool ExitConfirmation()
        {
            string strInput;
            bool isValid = false, result = false;

            do
            {
                Console.Clear();
                Console.WriteLine("You're leaving. Are you sure about that? [Yes / No]");

                strInput = Console.ReadLine()?.ToLower();

                if (ValidationHelper.IsYesOrNo(strInput))
                {
                    isValid = true;
                    if (strInput == "yes")
                        result = true;
                    else
                        result = false;
                }
                else
                {
                    Console.WriteLine("[ERROR]: Please choose a valid option!");
                    Thread.Sleep(1500);
                }
            } while (isValid == false);

            return result;
        }
    }
}
