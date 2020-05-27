using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.TryCatchException
{
    [Serializable]
    public class IzinTalepBaslangicBitistenIleriOlamazException : Exception
    {
        public IzinTalepBaslangicBitistenIleriOlamazException(string message) : base(message)
        {
        }
    }
}