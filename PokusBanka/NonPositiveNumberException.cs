using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokusBanka
{
    // výjimková třída pro případ, kdy se snažíme vložit nebo vybrat částku která je nulová nebo záporná
    public class NonPositiveNumberException : Exception
    {
        public NonPositiveNumberException() { }
        public NonPositiveNumberException(string message) : base(message) { }
        public NonPositiveNumberException(string message, Exception inner) :
            base (message, inner) { }

    }
}
