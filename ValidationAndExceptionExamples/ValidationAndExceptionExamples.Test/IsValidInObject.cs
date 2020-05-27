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
            var reqeust = new TimeOffRequestDto
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(-5)
            };

            var errors = reqeust.IsValid();

            Assert.IsTrue(errors.Any());

            Assert.IsTrue(errors.Contains("Start date cannot be greater than the end date"));
        }
    }
}
