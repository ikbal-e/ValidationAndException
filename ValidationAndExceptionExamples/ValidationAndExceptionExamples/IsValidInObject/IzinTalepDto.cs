using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.IsValidInObject
{
    public class IzinTalepDto
    {
        public decimal PersonelId { get; set; }
        public DateTime IzinBaslangic { get; set; }
        public DateTime IzinBitis { get; set; }
        public string Aciklama { get; set; }

        public IReadOnlyList<string> IsValid()
        {
            var errors = new List<string>();

            if (IzinBaslangic > IzinBitis)
                errors.Add("İzin başlangıç tarihi bitiş tarihinden büyük olamaz");

            if (IzinBitis.Subtract(IzinBaslangic).TotalDays < 365)
                errors.Add("En fazla bir yıllık izin planlanabilir");

            if (string.IsNullOrEmpty(Aciklama))
                errors.Add("Açıklama alanı girilmek zorunda");            

            return errors;
        }
    }
}