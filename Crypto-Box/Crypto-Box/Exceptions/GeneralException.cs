using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoBox.Exceptions
{
    public class GeneralException
    {
        public bool Result { get; set; }
        public string Message { get; set; }

        public GeneralException(bool result, string message = null)
        {
            this.Message = message;
            this.Result = result;
        }
    }
}
