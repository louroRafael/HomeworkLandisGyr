using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLandisGyr.Helpers
{
    public class ValidationHelper
    {
        public static bool IsYesOrNo(string str) => (str.ToLower() == "yes" || str.ToLower() == "no");

        public static bool IsNumber(string str) => int.TryParse(str, out _);

        public static bool EnumValidation<T>(string str) where T : Enum
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                var value = Convert.ToInt32(str);
                return Enum.IsDefined(typeof(T), value);
            }
            return false;
        }
    }
}
