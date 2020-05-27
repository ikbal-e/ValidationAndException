using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.IValidatable;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class IValidatable
    {
        [TestMethod]
        public void WithInvalidObject()
        {
            var izin = new IzinTalepDto
            {
                Aciklama = "deneme",
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(-5)
            };

            ValidationContext vcx = new ValidationContext(izin);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(izin, vcx, results, true);
            
            Assert.IsFalse(isValid);

            Assert.IsTrue(results.Select(x => x.ErrorMessage).Contains("İzin başlangıç tarihi bitiş tarihinden büyük olamaz"));

        }

        [TestMethod]
        public void WithNullAciklama()
        {
            // Aciklama alanı null olduğu için diğer hatalar ignore ediliyor, 
            // Priority = [Required] -> Other attributes -> IValidatableObject Implementation

            var izin = new IzinTalepDto
            {
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(-5)
            };

            ValidationContext vcx = new ValidationContext(izin);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(izin, vcx, results, true);

            Assert.IsFalse(isValid);

            Assert.IsTrue(results.Count == 1);

            Assert.IsFalse(results.Select(x => x.ErrorMessage).Contains("İzin başlangıç tarihi bitiş tarihinden büyük olamaz"));
            Assert.IsTrue(results.Select(x => x.ErrorMessage).Contains("Aciklama alanı gereklidir."));

        }
    }
}
