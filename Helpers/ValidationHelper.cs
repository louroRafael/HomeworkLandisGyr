using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLandisGyr.Helpers
{
    public class ValidationHelper
    {
        public bool IsYesOrNo(string str) => (str == "yes" || str == "no");
    }
}
