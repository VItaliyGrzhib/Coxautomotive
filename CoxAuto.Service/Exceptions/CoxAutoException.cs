using System;

namespace CoxAuto.Service.Exceptions
{
    public class CoxAutoException:Exception
    {

        public CoxAutoException(): base()
        {
        }


        public CoxAutoException(string? message):base(message)
        { 
        }

     
        public CoxAutoException(string? message, Exception? innerException): 
            base(message, innerException)
        { 
        }

    }
}
