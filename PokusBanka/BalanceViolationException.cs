using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokusBanka
{
    // výjimková třída pro případ, kdy se snažíme vybrat víc než je možné
    public class BalanceViolationException : Exception
    {
        public BalanceViolationException() { }
        public BalanceViolationException(string message) : base(message) { }
        public BalanceViolationException(string message, Exception inner) :
            base(message, inner) { }
    }
}
