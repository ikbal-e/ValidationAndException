using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.ResultClass;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class ResultClass
    {
        [TestMethod]
        public void TestIzinResultClassWithValidObject()
        {
            var izin = new IzinTalepDto
            {
                Aciklama = "Deneme",
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(3)
            };

            Assert.IsTrue(IzinVer(izin).Success);
        }

        [TestMethod]
        public void IzinResultWithInvalidAciklama()
        {
            var izin = new IzinTalepDto
            {
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(3)
            };

            var izinResult = IzinVer(izin);

            Assert.IsTrue(izinResult.Failure);
            Assert.AreEqual("Açıklama boş olamaz", izinResult.Error);
        }

        public Result IzinVer(IzinTalepDto izin)
        {
            if (izin.Aciklama == null) return Result.Fail("Açıklama boş olamaz");
            if (izin.IzinBaslangic > izin.IzinBitis) return Result.Fail("İzin başlangıcı, bitiş tarihinden ileride olamaz");

            return Result.Ok();
        }

        [TestMethod]
        public void GenericResultClassTestWithInvalidAciklama()
        {
            var izin = new IzinTalepDto
            {
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(3)
            };

            var izinResult = IzinVerWithGenericResult(izin);

            Assert.IsTrue(izinResult.Failure);
            Assert.AreEqual("Açıklama boş olamaz", izinResult.Error);
        }

        [TestMethod]
        public void GenericResultClassTestWithValidObject()
        {
            var izin = new IzinTalepDto
            {
                Aciklama = "Deneme",
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(3)
            };

            var izinResult = IzinVerWithGenericResult(izin);
            
            Assert.IsTrue(izinResult.Success);
            Assert.AreEqual(izin.Aciklama, izinResult.Value.Aciklama);
            Assert.AreEqual(null, izinResult.Error);
        }

        public Result<IzinTalepDto> IzinVerWithGenericResult(IzinTalepDto izin)
        {
            if (izin.Aciklama == null) return Result<IzinTalepDto>.Fail(izin, "Açıklama boş olamaz");
            if (izin.IzinBaslangic > izin.IzinBitis) return Result<IzinTalepDto>.Fail(izin, "İzin başlangıcı, bitiş tarihinden ileride olamaz");

            return Result<IzinTalepDto>.Ok(izin);
        }
    }
}
