using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.DataAnnotation
{
    public class IzinTalepDto
    {
        [Required]
        public decimal PersonelId { get; set; }
        public DateTime IzinBaslangic { get; set; }
        public DateTime IzinBitis { get; set; }
        [MinLength(10, ErrorMessage = "Açıklama en az 10 karakter olmak zorunda")]
        public string Aciklama { get; set; }

        //TODO IzinBaslangic < IzinBitis
        //custom ValidatonAttribute'ler yazmak gerekli
    }
}