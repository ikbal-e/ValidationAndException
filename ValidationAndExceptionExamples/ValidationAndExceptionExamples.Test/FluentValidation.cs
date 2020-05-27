using System;
using System.Linq;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.FluentValidation;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class FluentValidation
    {
        [TestMethod]
        public void IzinTalepDtoTestWithValidObject()
        {
            var izin = new IzinTalepDto
            {
                Aciklama = "Deneme",
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(3)
            };

            var izinValidator = new IzinTalepDtoValidator();
            var validatorResult = izinValidator.Validate(izin);

            Assert.IsTrue(validatorResult.IsValid);
        }

        [TestMethod]
        public void IzinTalepDtoTestWithInvalidObject()
        {
            var izin = new IzinTalepDto
            {
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(-5)
            };

            var izinValidator = new IzinTalepDtoValidator();
            var validatorResult = izinValidator.Validate(izin);

            Assert.IsFalse(validatorResult.IsValid);

            var errorMessages = validatorResult.Errors.Select(x => x.ErrorMessage);

            Assert.IsFalse(errorMessages.Contains("En fazla bir yıllık izin planlanabilir"));

            Assert.IsTrue(errorMessages.Contains("Açıklama girmek zorundasınız"));
            Assert.IsTrue(errorMessages.Contains("İzin başlangıcı, bitişten ileri bir tarihte olamaz"));
        }

        [TestMethod]
        public void FluentValidationWithToString()
        {
            var izin = new IzinTalepDto
            {
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(-22)
            };

            var izinValidator = new IzinTalepDtoValidator();
            var validatorResult = izinValidator.Validate(izin);

            var hataMesaji = validatorResult.ToString(", ");

            Assert.AreEqual("İzin başlangıcı, bitişten ileri bir tarihte olamaz, Açıklama girmek zorundasınız", hataMesaji);
        }

    }
}
