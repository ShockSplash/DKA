using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKA.CustomExceptions
{
    public class AlphabetException : Exception
    {
        public AlphabetException(string message) : base(message)
        {

        }
    }
}
