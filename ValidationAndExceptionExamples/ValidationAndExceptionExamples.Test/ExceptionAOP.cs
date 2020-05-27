using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.ExceptionAOP;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class ExceptionAOP
    {
        [TestMethod]
        public void ExceptionAOPTest()
        {
            var izin = new IzinTalepDto
            {
                Aciklama = "Deneme",
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(-3)
            };

            Assert.IsFalse(IzinVer(izin));

            //Assert.ThrowsException<IzinTalepBaslangicBitistenIleriOlamazException>(() => IzinVer(izin)); Bu test geçmeyecek çünkü exception yakalanıyor
        }

        [IzinTalepExceptionAspect]
        public bool IzinVer(IzinTalepDto izin)
        {
            if (izin.IzinBaslangic > izin.IzinBitis) throw new IzinTalepBaslangicBitistenIleriOlamazException("İzin başlangıcı, bitiş tarihinden ileride olamaz");

            return true;
        }

        [TestMethod]
        public void ExceptionAOPTestWithValidObject()
        {
            var izin = new IzinTalepDto
            {
                Aciklama = "Deneme",
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(5)
            };

            Assert.IsTrue(IzinVer(izin));
        }
    }
}
