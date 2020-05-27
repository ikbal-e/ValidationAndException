using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationAndExceptionExamples.IsValidInObject;

namespace ValidationAndExceptionExamples.Test
{
    [TestClass]
    public class IsValidInObject
    {
        [TestMethod]
        public void IsValidInObjectTest()
        {
            var izin = new IzinTalepDto
            {
                IzinBaslangic = DateTime.Now,
                IzinBitis = DateTime.Now.AddDays(-5)
            };

            var errors = izin.IsValid();

            Assert.IsTrue(errors.Any());

            Assert.IsTrue(errors.Contains("İzin başlangıç tarihi bitiş tarihinden büyük olamaz"));
        }
    }
}
