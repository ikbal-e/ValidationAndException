using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.TryCatchException;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class TryCatchException
    {
        [TestMethod]
        public void TryCatchWithInvalidDate()
        {
            var izin = new IzinTalepDto
            {
                Aciklama = "Deneme",
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(-33)
            };

            Assert.ThrowsException<IzinTalepBaslangicBitistenIleriOlamazException>(() => IzinVer(izin));
        }

        public void IzinVer(IzinTalepDto izin)
        {
            if (izin.Aciklama is null) throw new ArgumentNullException(nameof(izin.Aciklama), "Alan boş bırakılamaz");
            if (izin.IzinBaslangic > izin.IzinBitis) throw new IzinTalepBaslangicBitistenIleriOlamazException("İzin başlangıcı, bitiş tarihinden ileride olamaz");
        }

        [TestMethod]
        public void TryCatchWithInvalidAciklama()
        {
            var izin = new IzinTalepDto
            {
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(4)
            };

            try
            {
                IzinVer(izin);
            }
            catch(ArgumentNullException exp)
            {
                Assert.AreEqual("Alan boş bırakılamaz\r\nParametre adı: Aciklama", exp.Message);
            }
        }
    }
}
