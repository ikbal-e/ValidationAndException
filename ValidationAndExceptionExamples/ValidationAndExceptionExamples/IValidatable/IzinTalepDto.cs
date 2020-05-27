using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.IValidatable
{
    public class IzinTalepDto : IValidatableObject
    {
        public decimal PersonelId { get; set; }
        public DateTime IzinBaslangic { get; set; }
        public DateTime IzinBitis { get; set; }
        [Required]
        public string Aciklama { get; set; }      

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (IzinBaslangic > IzinBitis) 
                results.Add(new ValidationResult("İzin başlangıç tarihi bitiş tarihinden büyük olamaz"));

            if (IzinBitis.Subtract(IzinBaslangic).TotalDays < 365) 
                results.Add(new ValidationResult("En fazla bir yıllık izin planlanabilir"));

            return results;
        }
    }
}