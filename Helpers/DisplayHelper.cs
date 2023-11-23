using System.ComponentModel;

namespace ProjetoLandisGyr.Helpers
{
    public class DisplayHelper
    {
        public static void ShowTableHeader<T>() where T : class
        {
            foreach (var property in typeof(T).GetProperties())
            {
                Console.Write($" {property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single().DisplayName} ");
                if (property != typeof(T).GetProperties().Last())
                    Console.Write("|");
            }
            Console.WriteLine();
        }

        public static void ShowTableBody<T>(List<T> elements) where T : class
        {
            foreach (var element in elements)
            {
                foreach (var property in typeof(T).GetProperties())
                {
                    Console.Write($" {property.GetValue(element)} ");
                    if (property != typeof(T).GetProperties().Last())
                        Console.Write("|");
                }
                Console.WriteLine();
            }
        }

        public static void ShowTableBody<T>(T element) where T : class
        {
            foreach (var property in typeof(T).GetProperties())
            {
                Console.Write($" {property.GetValue(element)} ");
                if (property != typeof(T).GetProperties().Last())
                    Console.Write("|");
            }
            Console.WriteLine();
        }

        public static void ShowEnumOptions<T>() where T : Enum 
        {
            foreach (var option in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"[{(int)option}] - {option.ToString()}");
            }
        }
    }
}
