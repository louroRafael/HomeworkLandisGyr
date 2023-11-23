namespace ProjetoLandisGyr.Helpers
{
    public class ExceptionHelper
    {
        public static void ShowExceptionMessage(Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
            Console.WriteLine("\nPress any key to continue!");
            Console.ReadKey(true);
        }
    }
}
