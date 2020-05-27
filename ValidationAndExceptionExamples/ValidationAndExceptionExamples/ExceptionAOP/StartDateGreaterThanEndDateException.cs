using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.ExceptionAOP
{
    [Serializable]
    public class StartDateGreaterThanEndDateException : Exception
    {
        public StartDateGreaterThanEndDateException(string message) : base(message)
        {
        }
    }
}