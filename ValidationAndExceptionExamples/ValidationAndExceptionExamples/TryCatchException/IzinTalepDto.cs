using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.TryCatchException
{
    public class IzinTalepDto
    {
        public decimal PersonelId { get; set; }
        public DateTime IzinBaslangic { get; set; }
        public DateTime IzinBitis { get; set; }
        public string Aciklama { get; set; }
    }
}